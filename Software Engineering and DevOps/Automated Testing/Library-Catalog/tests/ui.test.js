const { expect, test } = require('@playwright/test');

async function loginTestUser(page) {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');
}

async function loginTestUser2(page) {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'krasi@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');
}

async function loginTestUser3(page) {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'john@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');
}

//#region Navigation Bar for Guest Users
test('Verify that "All Books" link is visible', async ({ page }) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const allBooksLink = await page.$('a[href="/catalog"]');
    const isLinkVisible = await allBooksLink.isVisible();

    expect(isLinkVisible).toBe(true);
});

test('Verify that "Login Button" link is visible', async ({ page }) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const loginButtonLink = await page.$('a[href="/catalog"]');
    const isBtnLoginLinkVisible = await loginButtonLink.isVisible();

    expect(isBtnLoginLinkVisible).toBe(true);
});

test('Verify that "Register Button" link is visible', async ({ page }) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const registerButtonLink = await page.$('a[href="/register"]');
    const isBtnRegisterLinkVisible = await registerButtonLink.isVisible();

    expect(isBtnRegisterLinkVisible).toBe(true);
});
//#endregion

//#region Navigation Bar for Logged-In Users
test('Verify that "All Books" link is visible after user has logged in', async ({ page }) => {
    await loginTestUser(page);

    await page.waitForSelector('nav.navbar');
    const allBooksLink = await page.$('a[href="/catalog"]');
    const isLinkVisible = await allBooksLink.isVisible();

    expect(isLinkVisible).toBe(true);
});

test('Verify that "My Books" link is visible after user has logged in', async ({ page }) => {
    await loginTestUser(page);

    await page.waitForSelector('nav.navbar');
    const myBooksLink = await page.$('a[href="/profile"]');
    const isLinkVisible = await myBooksLink.isVisible();

    expect(isLinkVisible).toBe(true);
});

test('Verify that "Add Book" link is visible after user has logged in', async ({ page }) => {
    await loginTestUser(page);

    await page.waitForSelector('nav.navbar');
    const addBookLink = await page.$('a[href="/create"]');
    const isLinkVisible = await addBookLink.isVisible();

    expect(isLinkVisible).toBe(true);
});

test('Verify that "User E-mail" is visible in the navBar after user has logged in', async ({ page }) => {
    await loginTestUser(page);

    await page.waitForSelector('div#user');
    const userEmail = await page.$('div#user > span');
    const isUserEmailVisible = await userEmail.isVisible();

    expect(isUserEmailVisible).toBe(true);
});
//#endregion

//#region Login Page
test('Submit Form with Valid Credentials works correctly', async ({ page }) => {
    await loginTestUser(page);

    await page.$('a[href="/catalog"]');

    expect(page.url()).toBe('http://localhost:3000/catalog');
});

test('Submit Form with Empty Fields response with dialog message"All fields are required!"', async ({ page }) => {
    await page.goto('http://localhost:3000/login');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/login"]');
    expect(page.url()).toBe('http://localhost:3000/login');
});

test('Submit Form with Empty E-mail and valid password works correctly', async ({ page }) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/login"]');
    expect(page.url()).toBe('http://localhost:3000/login');
});

test('Submit Form with Empty password and valid e-mail works correctly', async ({ page }) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/login"]');
    expect(page.url()).toBe('http://localhost:3000/login');
});
//#endregion

//#region Register Page
test('Submit Form with Valid Credentials to Register new User', async ({ page }) => {
    await page.goto('http://localhost:3000/register');
    await page.fill('input[name="email"]', 'krasi@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.fill('input[name="confirm-pass"]', '123456');
    await page.click('input[type="submit"]');

    await page.waitForSelector('nav.navbar');
    const allBooksLink = await page.$('a[href="/catalog"]');
    const isLinkVisible = await allBooksLink.isVisible();

    expect(isLinkVisible).toBe(true);
});

test('Submit Form with Empty Fields to Register new User responses with alert message', async ({ page }) => {
    await page.goto('http://localhost:3000/register');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/register"]');
    expect(page.url()).toBe('http://localhost:3000/register');
});

test('Submit Form with Empty Field for E-mail to Register new User responses with alert message', async ({ page }) => {
    await page.goto('http://localhost:3000/register');
    await page.fill('input[name="password"]', '123456');
    await page.fill('input[name="confirm-pass"]', '123456');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/register"]');
    expect(page.url()).toBe('http://localhost:3000/register');
});

test('Submit Form with Empty Field for Password to Register new User responses with alert message', async ({ page }) => {
    await page.goto('http://localhost:3000/register');
    await page.fill('input[name="email"]', 'krasi@abv.bg');
    await page.fill('input[name="password"]', '');
    await page.fill('input[name="confirm-pass"]', '123456');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/register"]');
    expect(page.url()).toBe('http://localhost:3000/register');
});

test('Submit Form with Empty Field for Confirm-Password to Register new User responses with alert message', async ({ page }) => {
    await page.goto('http://localhost:3000/register');
    await page.fill('input[name="email"]', 'krasi@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.fill('input[name="confirm-pass"]', '');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/register"]');
    expect(page.url()).toBe('http://localhost:3000/register');
});
//#endregion

//#region Add Book page
test('Add Book with correct data, adds the book to the server', async ({ page }) => {
    await loginTestUser(page);

    await page.click('a[href="/create"]');
    await page.waitForSelector('#create-form');
    await page.fill('#title', 'Test Book');
    await page.fill('#description', 'This is test description for the test book');
    await page.fill('#image', 'https://example.com/book-image.png');
    await page.selectOption('#type', 'Fiction');
    await page.click('#create-form input[type="submit"]');

    await page.waitForURL('http://localhost:3000/catalog');
    expect(page.url()).toBe('http://localhost:3000/catalog');
});

test('Add Book with empty Title field, responses with alert - All fields are required', async ({ page }) => {
    await loginTestUser(page);

    await page.click('a[href="/create"]');
    await page.waitForSelector('#create-form');
    await page.fill('#description', 'This is test description for the test book');
    await page.fill('#image', 'https://example.com/book-image.png');
    await page.selectOption('#type', 'Classic');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/create"]');
    expect(page.url()).toBe('http://localhost:3000/create');
});

test('Add Book with empty Description field, responses with alert - All fields are required', async ({ page }) => {
    await loginTestUser(page);

    await page.click('a[href="/create"]');
    await page.waitForSelector('#create-form');
    await page.fill('#title', 'Test Book');
    await page.fill('#image', 'https://example.com/book-image.png');
    await page.selectOption('#type', 'Romance');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/create"]');
    expect(page.url()).toBe('http://localhost:3000/create');
});

test('Add Book with empty URL field, responses with alert - All fields are required', async ({ page }) => {
    await loginTestUser(page);

    await page.click('a[href="/create"]');
    await page.waitForSelector('#create-form');
    await page.fill('#title', 'Test Book');
    await page.fill('#description', 'This is test description for the test book');
    await page.selectOption('#type', 'Other');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/create"]');
    expect(page.url()).toBe('http://localhost:3000/create');
});
//#endregion

//#region All Books page
test('Verify All Books are displayed after login', async ({ page }) => {
    await loginTestUser(page);

    await page.waitForSelector('.dashboard');
    const bookElements = await page.$$('.other-books-list li');

    expect(bookElements.length).toBeGreaterThan(0);
});

test('Verify No books are displayed, when database is empty', async ({ page }) => {
    await loginTestUser2(page);

    await page.click('a[href="/profile"]');

    const noBooksMessage = await page.textContent('p.no-books');
    expect(noBooksMessage).toBe('No books in database!');
});
//#endregion

//#region Details Page
test('Verify that Logged-in User Sees Details Button and Button works correctly', async ({ page }) => {
    await loginTestUser3(page);

    await page.click('a[href="/catalog"]');
    await page.waitForSelector('.otherBooks');
    await page.click('.otherBooks a.button');
    await page.waitForSelector('.book-information');

    const detailsPageTitle = await page.textContent('.book-information h3');
    expect(detailsPageTitle).toBe('Test Book');
});

test('Verify that Guest User Sees Details Button and Button works correctly', async ({ page }) => {
    await page.goto('http://localhost:3000/');
    await page.click('a[href="/catalog"]');
    await page.waitForSelector('.otherBooks');
    await page.click('.otherBooks a.button');
    await page.waitForSelector('.book-information');

    const detailsPageTitle = await page.textContent('.book-information h3');
    expect(detailsPageTitle).toBe('Test Book');
});

test('Verify that Guest User Sees Details Info of a Book correctly', async ({ page }) => {
    await page.goto('http://localhost:3000/');
    await page.click('a[href="/catalog"]');
    await page.waitForSelector('.otherBooks');

    const bookListItems = await page.$$('ul.other-books-list > li');

    for (const listItem of bookListItems) {
        const hasHeading = await listItem.$('h3') !== null;
        const hasType = await listItem.$('p') !== null;
        const hasImage = await listItem.$('p.img > img') !== null;
        const hasDetailsButton = await listItem.$('a.button[href^="/details/"]') !== null;

        expect(hasHeading).toBe(true);
        expect(hasType).toBe(true);
        expect(hasImage).toBe(true);
        expect(hasDetailsButton).toBe(true);
    }
});

test('Verify that Edit and Delete Buttons are Visible for Book Creator', async ({ page }) => {
    await loginTestUser(page);
    await page.goto('http://localhost:3000/details/2949b54d-b163-4a00-b65c-41fb8b641561');

    await page.waitForSelector('div.actions');
    const editButton = await page.$('div.actions > a.button[href^="/edit/"]');
    const isEditButtonVisible = editButton !== null;
    const deleteButton = await page.$('div.actions > a.button[href="javascript:void(0)"]');
    const isDeleteButtonVisible = deleteButton !== null;

    expect(isEditButtonVisible).toBe(true);
    expect(isDeleteButtonVisible).toBe(true);
});

test('Verify that Edit and Delete Buttons are not Visible for User that is not the creator of the book', async ({ page }) => {
    await page.goto('http://localhost:3000/details/dd9f9b2d-eef8-4b8c-9e0f-2a70c48e7f5f');

    await page.waitForSelector('div.actions');
    const editButton = await page.$('div.actions > a.button[href^="/edit/"]');
    const isEditButtonNotVisible = editButton === null;
    const deleteButton = await page.$('div.actions > a.button[href="javascript:void(0)"]');
    const isDeleteButtonNotVisible = deleteButton === null;

    expect(isEditButtonNotVisible).toBe(true);
    expect(isDeleteButtonNotVisible).toBe(true);
});

test('Verify that Like Button is Visible for User that is NOT the creator of the book', async ({ page }) => {
    await loginTestUser2(page);
    await page.goto('http://localhost:3000/details/b559bd24-5fb6-4a42-bc48-40c17dea649d');

    await page.waitForSelector('div.actions');
    const likeButton = await page.$('div.actions > a.button[href="javascript:void(0)"]');
    const buttonText = await likeButton.isVisible();

    expect(buttonText).toBe(true);
});

test('Verify that Like Button is NOT Visible for User that is the creator of the book', async ({ page }) => {
    await loginTestUser(page);
    await page.goto('http://localhost:3000/details/b559bd24-5fb6-4a42-bc48-40c17dea649d');

    const likeButton = await page.$('div.actions > a.button[href="javascript:void(0)"]');

    expect(likeButton).toBeNull();
});
//#endregion

//#region Logout Functionality
test('Verify that "Logout" link is visible after user has logged in', async ({ page }) => {
    await loginTestUser(page);

    await page.waitForSelector('div#user');
    const logOutBtnLink = await page.$('div#user > a#logoutBtn');
    const isLinkVisible = await logOutBtnLink.isVisible();

    expect(isLinkVisible).toBe(true);
});

test('Verify that "Logout" link redirects correctly logged-out user', async ({ page }) => {
    await loginTestUser(page);

    await page.waitForSelector('div#user');
    const logOutBtnLink = await page.$('div#user > a#logoutBtn');
    await logOutBtnLink.click();

    const redirectedUrl = page.url();
    expect(redirectedUrl).toBe('http://localhost:3000/catalog')
});
//#endregion