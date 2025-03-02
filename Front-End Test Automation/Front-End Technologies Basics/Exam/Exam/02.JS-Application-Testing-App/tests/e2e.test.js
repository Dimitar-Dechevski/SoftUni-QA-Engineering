const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email: "",
    password: "123456",
    confirmPass: "123456",
};

let bookTitle = "";

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });


    describe("authentication", () => {
        test('Registration with valid data', async () => {
            // Arrange
            await page.goto(host);
            let randomNumber = Math.floor(Math.random() * (9999 - 999 + 1)) + 999;
            user.email = `User_${randomNumber}@abv.bg`;

            // Act
            await page.click('//a[@href="/register"]');
            await page.waitForSelector('//form');

            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.locator('//input[@name="conf-pass"]').fill(user.confirmPass);
            await page.click('//button[@type="submit"]');

            // Assert
            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test('Login with valid data', async () => {
            // Arrange
            await page.goto(host);

            // Act
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');

            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            // Assert
            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test('Logout from the application', async () => {
            // Arrange
            await page.goto(host);

            // Act
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');

            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
            await page.click('//a[@href="/logout"]');

            // Assert
            await expect(page.locator('//a[@href="/login"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });
    });

    describe("navbar", () => {
        test('Navigation for logged in user', async () => {
            // Arrange
            await page.goto(host);

            // Act
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');

            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            // Assert
            await expect(page.locator('//a[@href="/"]')).toBeVisible();
            await expect(page.locator('//a[@href="/collection"]')).toBeVisible();
            await expect(page.locator('//a[@href="/search"]')).toBeVisible();
            await expect(page.locator('//a[@href="/create"]')).toBeVisible();
            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();

            await expect(page.locator('//a[@href="/login"]')).toBeHidden();
            await expect(page.locator('//a[@href="/register"]')).toBeHidden();
        });

        test('Navigation for non logged in user', async () => {
            // Act
            await page.goto(host);

            // Assert
            await expect(page.locator('//a[@href="/"]')).toBeVisible();
            await expect(page.locator('//a[@href="/collection"]')).toBeVisible();
            await expect(page.locator('//a[@href="/search"]')).toBeVisible();
            await expect(page.locator('//a[@href="/login"]')).toBeVisible();
            await expect(page.locator('//a[@href="/register"]')).toBeVisible();

            await expect(page.locator('//a[@href="/create"]')).toBeHidden();
            await expect(page.locator('//a[@href="/logout"]')).toBeHidden();
        })
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');

            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');
        });

        test('Create a book', async () => {
            // Arrange
            await page.click('//a[@href="/create"]');
            await page.waitForSelector('//form');
            let randomNumber = Math.floor(Math.random() * (9999 - 999 + 1)) + 999;
            bookTitle = `Book_${randomNumber}`;

            // Act
            await page.locator('//input[@id="title"]').fill(bookTitle);
            await page.locator('//input[@id="coverImage"]').fill('https://cdn.pixabay.com/photo/2018/01/17/18/43/book-3088775_1280.jpg');
            await page.locator('//input[@id="year"]').fill('1999');
            await page.locator('//input[@id="author"]').fill('Test Author');
            await page.locator('//input[@id="genre"]').fill('Test Genre');
            await page.locator('//textarea[@name="description"]').fill('Test Description');
            await page.locator('//button[@class="save-btn"]').scrollIntoViewIfNeeded();
            await page.click('//button[@class="save-btn"]');

            // Assert
            await expect(page.locator('//div[@class="book-details"]//h2', { hasText: bookTitle })).toHaveCount(1);
            expect(page.url()).toBe(host + '/collection');
        });

        test('Edit a book', async () => {
            // Arrange
            await page.click('//a[@href="/search"]');

            // Act
            await page.locator('//input[@name="search"]').fill(bookTitle);
            await page.click('//button[@type="submit"]');
            await page.locator('//li//a', { hasText: bookTitle }).scrollIntoViewIfNeeded();
            await page.click('//li//a', { hasText: bookTitle });
            await page.locator('//a[@class="edit-btn"]').scrollIntoViewIfNeeded();
            await page.click('//a[@class="edit-btn"]');
            await page.waitForSelector('//form');
            bookTitle = 'New_' + bookTitle
            await page.locator('//input[@id="title"]').fill(bookTitle);
            await page.locator('//button[@class="save-btn"]').scrollIntoViewIfNeeded();
            await page.click('//button[@class="save-btn"]');

            // Assert
            await expect(page.locator('//div[@class="book-info"]//h2', { hasText: bookTitle })).toHaveCount(1);
        });

        test('Delete a book', async () => {
            // Arrange
            await page.click('//a[@href="/search"]');

            // Act
            await page.locator('//input[@name="search"]').fill(bookTitle);
            await page.click('//button[@type="submit"]');
            await page.locator('//li//a', { hasText: bookTitle }).scrollIntoViewIfNeeded();
            await page.click('//li//a', { hasText: bookTitle });
            await page.locator('//a[@class="delete-btn"]').scrollIntoViewIfNeeded();
            await page.click('//a[@class="delete-btn"]');

            // Assert
            await expect(page.locator('//div[@class="book-details"]//h2', { hasText: bookTitle })).toHaveCount(0);
            expect(page.url()).toBe(host + '/collection');
        })
    });
});