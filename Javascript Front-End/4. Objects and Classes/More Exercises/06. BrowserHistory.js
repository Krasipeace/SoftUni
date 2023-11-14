function getBrowserHistory(browser, actions) {
    for (let action of actions) {
        let [command, site] = action.split(' ');

        if (command === 'Open') {
            openTabs(browser, site, action);
        } else if (command === 'Close') {
            closeTabs(browser, site, action);
        } else if (action === 'Clear History and Cache') {
            clearTabs(browser);
        }
    }

    printBrowserHistory(browser);

    function openTabs(browser, website, action) {
        browser["Open Tabs"].push(website);
        browser["Browser Logs"].push(action);
    }

    function closeTabs(browser, website, action) {
        if (browser["Open Tabs"].includes(website)) {
            browser["Open Tabs"].splice(browser["Open Tabs"].indexOf(website), 1);
            browser["Recently Closed"].push(website);
            browser["Browser Logs"].push(action);
        }
    }

    function clearTabs(browser) {
        browser["Open Tabs"] = [];
        browser["Recently Closed"] = [];
        browser["Browser Logs"] = [];
    }

    function printBrowserHistory(browser) {
        console.log(browser["Browser Name"]);
        console.log(`Open Tabs: ${browser["Open Tabs"].join(", ")}`);
        console.log(`Recently Closed: ${browser["Recently Closed"].join(", ")}`);
        console.log(`Browser Logs: ${browser["Browser Logs"].join(", ")}`);
    }
}

getBrowserHistory({
    "Browser Name": "Google Chrome", "Open Tabs": ["Facebook", "YouTube", "Google Translate"],
    "Recently Closed": ["Yahoo", "Gmail"],
    "Browser Logs": ["Open YouTube", "Open Yahoo", "Open Google Translate", "Close Yahoo", "Open Gmail", "Close Gmail", "Open Facebook"]
},
    ["Close Facebook", "Open StackOverFlow", "Open Google"]
);
// Google Chrome
// Open Tabs: YouTube, Google Translate, StackOverFlow, Google
// Recently Closed: Yahoo, Gmail, Facebook
// Browser Logs: Open YouTube, Open Yahoo, Open Google Translate, Close Yahoo, Open Gmail, Close Gmail, Open Facebook, Close Facebook, Open StackOverFlow, Open Google
getBrowserHistory({
        "Browser Name": "Mozilla Firefox",
        "Open Tabs": ["YouTube"],
        "Recently Closed": ["Gmail", "Dropbox"],
        "Browser Logs": ["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]
    },
    ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
);
// Mozilla Firefox
// Open Tabs: Twitter
// Recently Closed: 
// Browser Logs: Open Twitter