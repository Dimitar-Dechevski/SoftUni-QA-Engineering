const { test, expect } = require('@playwright/test');

// Verify if a user can add a task
test('user can add a task', async ({ page }) => {
    // Add task
    await page.goto('http://localhost:8080/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    let taskText = await page.textContent('.task');
    expect(taskText).toContain('Test Task');
});

// Verify if a user can delete a task
test('user can delete a task', async ({ page }) => {
    // Add task
    await page.goto('http://localhost:8080/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');

    // Delete task
    await page.click('.task .delete-task')
    let tasks = await page.$$eval('.task', task => task.map(task => task.textContent));
    expect(tasks).not.toContain('Test Task');
})

// Verify if a user can mark a task as complete
test('user can mark a task as complete', async ({ page }) => {
    // Add task
    await page.goto('http://localhost:8080/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');

    // Mark task as complete
    await page.click('.task .task-complete');
    let completedTask = await page.$('.task.completed');
    expect(completedTask).not.toBeNull();
})

// Verify if a user can filter tasks
test('user can filter tasks', async ({ page }) => {
    // Add task
    await page.goto('http://localhost:8080/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');

    // Mark task as complete
    await page.click('.task .task-complete');

    // Filter tasks
    await page.selectOption('#filter', "Completed");
    let incompletedTask = await page.$('.task:not(.completed)');
    expect(incompletedTask).toBeNull();
})
