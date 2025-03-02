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

let albumName = "";

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
            await page.click('//button[@class="register"]');

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
            await page.click('//button[@class="login"]');

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
            await page.click('//button[@class="login"]');

            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
            page.click('//a[@href="/logout"]');

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
            await page.click('//button[@class="login"]');

            // Assert
            await expect(page.locator('//a[@href="/"]')).toBeVisible();
            await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();
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
            await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();
            await expect(page.locator('//a[@href="/search"]')).toBeVisible();
            await expect(page.locator('//a[@href="/login"]')).toBeVisible();
            await expect(page.locator('//a[@href="/register"]')).toBeVisible();

            await expect(page.locator('//a[@href="/create"]')).toBeHidden();
            await expect(page.locator('//a[@href="/logout"]')).toBeHidden();
        });
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');
            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@class="login"]');
        });

        test('Create an album', async () => {
            // Arrange
            await page.click('//a[@href="/create"]');
            await page.waitForSelector('//form');
            let randomNumber = Math.floor(Math.random() * (9999 - 999 + 1)) + 999;
            albumName = `AlbumName_${randomNumber}`;

            // Act
            await page.locator('//input[@name="name"]').fill(albumName);
            await page.locator('//input[@name="imgUrl"]').fill('https://png.pngtree.com/thumb_back/fh260/background/20210115/pngtree-electronic-music-album-image_528773.jpg');
            await page.locator('//input[@name="price"]').fill('33.33');
            await page.locator('//input[@name="releaseDate"]').fill('06.09.2003');
            await page.locator('//input[@name="artist"]').fill('Test Artist');
            await page.locator('//input[@name="genre"]').fill('Test Genre');
            await page.locator('//textarea[@name="description"]').fill('Test Description');
            await page.locator('//button[@class="add-album"]').scrollIntoViewIfNeeded();
            await page.click('//button[@class="add-album"]');

            // Assert
            await expect(page.locator('//div[@class="text-center"]//p[@class="name"]', { hasText: albumName })).toHaveCount(1);
            expect(page.url()).toBe(host + '/catalog');
        });

        test('Edit an album', async () => {
            // Arrange
            await page.click('//a[@href="/search"]');

            // Act
            await page.locator('//input[@name="search"]').fill(albumName);
            await page.click('//button[@class="button-list"]');
            await page.locator(page.locator('//div[@class="text-center"]//p[@class="name"]', { hasText: albumName }))
            await page.locator('//div[@class="btn-group"]//a[@id="details"]').scrollIntoViewIfNeeded();
            await page.click('//div[@class="btn-group"]//a[@id="details"]');
            await page.locator('//div[@class="actionBtn"]//a[@class="edit"]').scrollIntoViewIfNeeded();
            await page.click('//div[@class="actionBtn"]//a[@class="edit"]');
            await page.waitForSelector('//form');
            albumName = 'New_' + albumName;
            await page.locator('//input[@name="name"]').fill(albumName);
            await page.locator('//button[@class="edit-album"]').scrollIntoViewIfNeeded();
            await page.click('//button[@class="edit-album"]');

            // Assert
            await expect(page.locator('//div[@class="albumText"]//h1', { hasText: albumName })).toHaveCount(1);
        });

        test('Delete an album', async () => {
            // Arrange
            await page.click('//a[@href="/search"]');

            // Act
            await page.locator('//input[@name="search"]').fill(albumName);
            await page.click(('//button[@class="button-list"]'));
            await page.locator(page.locator('//div[@class="text-center"]//p[@class="name"]', { hasText: albumName }))
            await page.locator('//div[@class="btn-group"]//a[@id="details"]').scrollIntoViewIfNeeded();
            await page.click('//div[@class="btn-group"]//a[@id="details"]');
            await page.locator('//div[@class="actionBtn"]//a[@class="remove"]').scrollIntoViewIfNeeded();
            await page.click('//div[@class="actionBtn"]//a[@class="remove"]');

            // Assert
            await expect(page.locator('//div[@class="text-center"]//p[@class="name"]', { hasText: albumName })).toHaveCount(0);
            expect(page.url()).toBe(host + '/catalog');
        });
    });
});