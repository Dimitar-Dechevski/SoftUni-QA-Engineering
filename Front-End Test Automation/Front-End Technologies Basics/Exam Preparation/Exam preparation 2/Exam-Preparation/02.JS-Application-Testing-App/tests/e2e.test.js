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

let petName = "";

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
            await page.locator('//input[@name="repeatPassword"]').fill(user.confirmPass);
            await page.click('//button[text()="Register"]');

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
            await page.click('//button[text()="Login"]');

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
            await page.click('//button[text()="Login"]');

            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
            await page.click('//a[@href="/logout"]');

            // Assert
            await expect(page.locator('//a[@href="/login"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });
    })

    describe("navbar", () => {
        test('Navigation for logged in user', async () => {
            // Arrange
            await page.goto(host);

            // Act
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');

            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[text()="Login"]');

            // Assert
            await expect(page.locator('//a[@href="/"]')).toBeVisible();
            await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();
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
            await page.click('//button[text()="Login"]');
        });

        test('Create a postcard', async () => {
            // Arrange
            await page.click('//a[@href="/create"]');
            await page.waitForSelector('//form');
            let randomNumber = Math.floor(Math.random() * (9999 - 999 + 1)) + 999;
            petName = `PetName_${randomNumber}`;

            // Act
            await page.locator('//input[@name="name"]').fill(petName);
            await page.locator('//input[@name="breed"]').fill('German Shepherd');
            await page.locator('//input[@name="age"]').fill('4 years');
            await page.locator('//input[@name="weight"]').fill('35kg');
            await page.locator('//input[@name="image"]').fill('https://blog.gudog.co.uk/wp-content/uploads/2023/11/german-sherperd.jpeg');
            await page.locator('//button[text()="Create"]').scrollIntoViewIfNeeded();
            await page.click('//button[text()="Create"]');

            // Assert
            await expect(page.locator('//div[@class="animals-board"]//h2[@class="name"]', { hasText: petName })).toHaveCount(1);
            expect(page.url()).toBe(host + '/catalog');
        });

        test('Edit a postcard', async () => {
            // Arrange
            await page.click('//a[@href="/catalog"]');

            // Act
            await page.locator('//div[@class="animals-board"]//h2', { hasText: petName });
            await page.click('//a[@class="btn"]');
            await page.locator('//a[@class="edit"]').scrollIntoViewIfNeeded();
            await page.click('//a[@class="edit"]');
            await page.waitForSelector('//form');
            petName = 'New_' + petName;
            await page.locator('//input[@name="name"]').fill(petName);
            await page.click('//button[text()="Edit"]');

            // Assert
            await expect(page.locator('//div[@class="animalInfo"]//h1', { hasText: petName })).toHaveCount(1);
        });

        test('Delete a postcard', async () => {
            // Arrange
            await page.click('//a[@href="/catalog"]');

            // Act
            await page.locator('//div[@class="animals-board"]//h2', { hasText: petName });
            await page.click('//a[@class="btn"]');
            await page.locator('//a[@class="remove"]').scrollIntoViewIfNeeded();
            await page.click('//a[@class="remove"]');

            // Assert
            await expect(page.locator('//div[@class="animals-board"]//h2[@class="name"]', { hasText: petName })).toHaveCount(0);
            expect(page.url()).toBe(host + '/catalog');
        });
    });
})