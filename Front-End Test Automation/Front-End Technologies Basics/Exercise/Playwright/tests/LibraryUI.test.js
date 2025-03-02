const { test, expect } = require('@playwright/test');

// Verify that All Books link is visible
test('All Books link is visible', async ({ page }) => {
    // Act
    await page.goto('http://localhost:3000/');
    await page.waitForSelector('//nav[@class="navbar"]')

    // Assert 
    await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();
})

// Verify that Login button is visible
test('Login button is visible', async ({ page }) => {
    // Act
    await page.goto('http://localhost:3000/');
    await page.waitForSelector('//nav[@class="navbar"]')

    // Assert 
    await expect(page.locator('//a[@href="/login"]')).toBeVisible();
})

// Verify that Register button is visible
test('Register button is visible', async ({ page }) => {
    // Act
    await page.goto('http://localhost:3000/');
    await page.waitForSelector('//nav[@class="navbar"]');

    // Assert 
    await expect(page.locator('//a[@href="/register"]')).toBeVisible();
})

// Verify that All Books link is visible after user logged in
test('All Books link is visible after user logged in', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]');

    // Assert
    await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();
})

// Verify that My Books link is visible after user logged in
test('My Books link is visible after user logged in', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]');

    // Assert
    await expect(page.locator('//a[@href="/profile"]')).toBeVisible();
})

// Verify that Add Book link is visible after user logged in
test('Add Book link is visible after user logged in', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]');

    // Assert
    await expect(page.locator('//a[@href="/create"]')).toBeVisible();
})

// Verify that User Email Address is visible after user logged in
test('User Email Address is visible after user logged in', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]');

    // Assert
    await expect(page.locator('//div[@id="user"]//span')).toBeVisible();
})

// Verify that Login with valid credentials is successfully
test('Login with valid credentials is successfully', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]');
    await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();

    // Assert
    expect(page.url()).toBe("http://localhost:3000/catalog");
})

// Verify that Login with empty input fields is failed
test('Login with empty input fields is failed', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/login");
})

// Verify that Login with empty email field and valid password field is failed
test('Login with empty email field and valid password field is failed', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="password"]').fill('123456');
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/login");
})

// Verify that Login with empty password field and valid email field is failed
test('Login with empty password field and valid email field is failed', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/login");
})

// Verify that Register with valid credentials is successfully
test('Register with valid credentials is successfully', async ({ page }) => {
    // Arrange
    let randomNumber = Math.floor(Math.random() * (9999 - 999 + 1)) + 999;
    await page.goto('http://localhost:3000/register');

    // Act
    await page.locator('//input[@name="email"]').fill(`user${randomNumber}@abv.bg`);
    await page.locator('//input[@name="password"]').fill('123456');
    await page.locator('//input[@name="confirm-pass"]').fill('123456');
    await page.click('//input[@type="submit"]');
    await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();

    // Assert
    expect(page.url()).toBe("http://localhost:3000/catalog");
})

// Verify that Register with empty input fields is failed
test('Register with empty input fields is failed', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/register');

    // Act
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/register");
})

// Verify that Register with empty email field and valid password and confirm password fields is failed
test('Register with empty email field and valid password and confirm password fields is failed', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/register');

    // Act
    await page.locator('//input[@name="password"]').fill('123456');
    await page.locator('//input[@name="confirm-pass"]').fill('123456');
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/register");
})

// Verify that Register with empty password field and valid email and confirm password fields is failed
test('Register with empty password field and valid email and confirm password fields is failed', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/register');

    // Act
    await page.locator('//input[@name="email"]').fill('user8@abv.bg');
    await page.locator('//input[@name="confirm-pass"]').fill('123456');
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/register");
})

// Verify that Register with empty confirm password field and valid email and password fields is failed
test('Register with empty confirm password field and valid email and password fields is failed', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/register');

    // Act
    await page.locator('//input[@name="email"]').fill('user8@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/register");
})

// Verify that Register with valid email but different passwords in the two password fields is failed
test('Register with valid email but different passwords in the two password fields is failed', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/register');

    // Act
    await page.locator('//input[@name="email"]').fill('user8@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.locator('//input[@name="confirm-pass"]',).fill('654321');
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe(`Passwords don't match!`);
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/register");
})

// Verify that Add book with correct data is successfully after user logged in
test('Add book with correct data is successfully after user logged in', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]')
    await page.waitForURL('http://localhost:3000/catalog');
    await page.click('//a[@href="/create"]');
    await page.waitForSelector('//form');
    await page.locator('//input[@name="title"]').fill('Test Book');
    await page.locator('//textarea[@name="description"]').fill('Test Book Description');
    await page.locator('//input[@name="imageUrl"]').fill('https://upload.wikimedia.org/wikipedia/en/0/05/Littleprince.JPG');
    await page.selectOption('//select[@name="type"]', 'Classic');
    await page.click('//input[@type="submit"]');
    await page.waitForURL('http://localhost:3000/catalog');

    // Assert
    expect(page.url()).toBe('http://localhost:3000/catalog');
})

// Verify that Add book with empty title field is failed after user logged in
test('Add book with empty title field is failed after user logged in', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]')
    await page.waitForURL('http://localhost:3000/catalog');
    await page.click('//a[@href="/create"]');
    await page.waitForSelector('//form');
    await page.locator('//textarea[@name="description"]').fill('Test Book Description');
    await page.locator('//input[@name="imageUrl"]').fill('https://upload.wikimedia.org/wikipedia/en/0/05/Littleprince.JPG');
    await page.selectOption('//select[@name="type"]', 'Classic');
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/create");
})

// Verify that Add book with empty description field is failed after user logged in
test('Add book with empty description field is failed after user logged in', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]')
    await page.waitForURL('http://localhost:3000/catalog');
    await page.click('//a[@href="/create"]');
    await page.waitForSelector('//form');
    await page.locator('//input[@name="title"]').fill('Test Book');
    await page.locator('//input[@name="imageUrl"]').fill('https://upload.wikimedia.org/wikipedia/en/0/05/Littleprince.JPG');
    await page.selectOption('//select[@name="type"]', 'Classic');
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/create");
})

// Verify that Add book with empty image URL field is failed after user logged in
test('Add book with empty image URL field is failed after user logged in', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]')
    await page.waitForURL('http://localhost:3000/catalog');
    await page.click('//a[@href="/create"]');
    await page.waitForSelector('//form');
    await page.locator('//input[@name="title"]').fill('Test Book');
    await page.locator('//textarea[@name="description"]').fill('Test Book Description');
    await page.selectOption('//select[@name="type"]', 'Classic');
    page.on('dialog', async dialog => {
        expect(dialog.type()).toBe('alert');
        expect(dialog.message()).toBe('All fields are required!');
        await dialog.accept();
    });
    await page.click('//input[@type="submit"]');

    // Assert
    expect(page.url()).toBe("http://localhost:3000/create");
})

// Verify that All added books are displayed after user logged in
test('All added books are displayed after user logged in', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]');
    await page.waitForURL('http://localhost:3000/catalog');
    await page.waitForSelector('//section[@class="dashboard"]');
    let bookElements = await page.locator('//li[@class="otherBooks"]');
    let numberOfBookElements = await bookElements.count();

    // Assert
    expect(numberOfBookElements).toBeGreaterThan(0);
})

// Verify that When in the database are no books, a specific message is displayed after user logged in
// Delete all books manually
test('When in the database are no books, a specific message is displayed after user logged in', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]')
    await page.waitForURL('http://localhost:3000/catalog');

    // Assert
    await expect(page.locator('//p[@class="no-books"]')).toContainText('No books in database!');
})

// Verify that Logged user can navigate to Details page
test('Logged user can navigate to Details page', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]')
    await page.waitForURL('http://localhost:3000/catalog');
    await page.waitForSelector('//section[@class="dashboard"]');
    await page.click('//a[text()="Details"]');

    // Assert
    await expect(page.locator('//div[@class="book-information"]//h3', { hasText: 'Test Book' })).toHaveCount(1);
})

// Verify that Non-Logged user can navigate to Details page
test('Non-Logged user can navigate to Details page', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.click('//a[@href="/catalog"]');
    await page.waitForURL('http://localhost:3000/catalog');
    await page.waitForSelector('//section[@class="dashboard"]');
    await page.click('//a[text()="Details"]');

    // Assert
    await expect(page.locator('//div[@class="book-information"]//h3', { hasText: 'Test Book' })).toHaveCount(1);
})

// Verify that All of the book information is correct
test('All of the book information is correct', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]')
    await page.waitForURL('http://localhost:3000/catalog');
    await page.waitForSelector('//section[@class="dashboard"]');
    await page.click('//a[text()="Details"]');

    // Assert
    await expect(page.locator('//div[@class="book-information"]//h3')).toContainText('Test Book');
    await expect(page.locator('//div[@class="book-description"]//p')).toContainText('Test Book Description');
    await expect(page.locator('//div[@class="book-information"]//p[@class="type"]')).toContainText('Classic');
    await expect(page.locator('//div[@class="book-information"]//p[@class="img"]//img')).toHaveAttribute('src', 'https://upload.wikimedia.org/wikipedia/en/0/05/Littleprince.JPG');
})

// Verify that Creator of the book can see Edit and Delete buttons
test('Creator of the book can see the Edit and Delete buttons', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]')
    await page.waitForURL('http://localhost:3000/catalog');
    await page.waitForSelector('//section[@class="dashboard"]');
    await page.click('//a[text()="Details"]');

    // Assert
    await expect(page.locator('//a[text()="Edit"]')).toBeVisible();
    await expect(page.locator('//a[text()="Delete"]')).toBeVisible();
})

// Verify that Users other than the creator of the book should not see Edit and Delete buttons
test('Users other than the creator of the book should not see Edit and Delete buttons', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('john@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]')
    await page.waitForURL('http://localhost:3000/catalog');
    await page.waitForSelector('//section[@class="dashboard"]');
    await page.click('//a[text()="Details"]');

    // Assert
    await expect(page.locator('//a[text()="Edit"]')).toBeHidden();
    await expect(page.locator('//a[text()="Delete"]')).toBeHidden();
})

// Verify that Creator of the book should not see Like button
test('Creator of the book should not see Like button', async ({ page }) => {
     // Arrange
     await page.goto('http://localhost:3000/login');

     // Act
     await page.locator('//input[@name="email"]').fill('peter@abv.bg');
     await page.locator('//input[@name="password"]').fill('123456');
     await page.click('//input[@type="submit"]')
     await page.waitForURL('http://localhost:3000/catalog');
     await page.waitForSelector('//section[@class="dashboard"]');
     await page.click('//a[text()="Details"]');
 
     // Assert
     await expect(page.locator('//a[text()="Like"]')).toBeHidden();
})

// Verify that Users other than the creator of the book can see Like button
test('Users other than the creator of the book can see Like button', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('john@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]')
    await page.waitForURL('http://localhost:3000/catalog');
    await page.waitForSelector('//section[@class="dashboard"]');
    await page.click('//a[text()="Details"]');

    // Assert
    await expect(page.locator('//a[text()="Like"]')).toBeVisible();
})

// Verify that Logout button is visible after user login
test('Logout button is visible after user login', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]');
    await page.waitForURL('http://localhost:3000/catalog');

    // Assert
    await expect(page.locator('//a[@href="javascript:void(0)"]')).toBeVisible();
})

// Verify that Logout button redirects users to correct URL page after user login
test('Logout button redirects users to correct URL page after user login', async ({ page }) => {
    // Arrange
    await page.goto('http://localhost:3000/login');

    // Act
    await page.locator('//input[@name="email"]').fill('peter@abv.bg');
    await page.locator('//input[@name="password"]').fill('123456');
    await page.click('//input[@type="submit"]');
    await page.click('//a[@href="javascript:void(0)"]');

    // Assert
    expect(page.url()).toBe('http://localhost:3000/catalog')
})
