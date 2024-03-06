const { test, expect } = require('@playwright/test');

test('User can add a task', async ({ page }) => {
    await page.goto('http://localhost:5500/');
    await page.fill('#task-input', 'Get more sleep');
    await page.click('#add-task');

    const taskText = await page.textContent('.task');
    expect(taskText).toContain('Get more sleep');
});

test('User can delete a task', async ({ page }) => {
    await page.goto('http://localhost:5500/');
    await page.fill('#task-input', 'Get more sleep');
    await page.click('#add-task');
    await page.click('.task .delete-task');

    const tasks = await page.$$eval('.task', tasks => tasks.map(task => task.textContent));
    expect(tasks).not.toContain('Get more sleep');
});

test('User can mark a task as complete', async ({ page }) => {
    await page.goto('http://localhost:5500/');
    await page.fill('#task-input', 'Get more sleep');
    await page.click('#add-task');
    await page.click('.task .task-complete');

    const completedTask = await page.$('.task.completed');
    expect(completedTask).not.toBeNull();
});

test('User can filter tasks', async ({ page }) => {
    await page.goto('http://localhost:5500/');
    await page.fill('#task-input', 'Get more sleep');
    await page.click('#add-task');
    await page.click('.task .task-complete');

    await page.selectOption('#filter', 'Completed');

    const incompleteTask = await page.$('.task:not(.completed)');
    expect(incompleteTask).toBeNull();
});