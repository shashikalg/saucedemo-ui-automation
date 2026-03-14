# SauceDemo UI Automation Framework

A UI automation framework built to automate core e-commerce user flows on the SauceDemo application.

## Tech Stack

* C#
* .NET 6
* Selenium WebDriver
* NUnit
* GitHub Actions

## Project Setup

1. Clone the repository

```bash
git clone https://github.com/shashikalg/saucedemo-ui-automation.git
```

2. Open the solution file

```text
SauceDemoUIAutomation.sln
```

3. Restore dependencies

```bash
dotnet restore
```

## Project Structure

```text
Common/              common files/constants
Config/              environment configuration
TestData/            test data (e.g: users/ products)
Pages/               page objects and reusable modules
Functions/           business flow layer
Helpers/             utility classes
Factories/           WebDriver factory
Models/              data models
Tests/               NUnit test classes
.github/workflows/   GitHub Actions CI workflow
```

## Run Tests

```bash
dotnet test
```

Run with test results:

```bash
dotnet test --logger "trx;LogFileName=test-results.trx"
```

## CI Execution

Workflow file:

```text
.github/workflows/sauce-demo-tests.yml
```

Runs on:

* push to main
* pull request to main
* manual workflow trigger

## Configuration

```text
Config/appsettings.json
```

Example:

```json
{
  "BaseUrl": "https://www.saucedemo.com/",
  "Browser": "Chrome",
  "HeadlessMode": true
}
```

## Special Considerations / Assumptions

* Chrome is currently supported.
* Headless mode is recommended for CI execution.
* Tests run against the public SauceDemo application.
* Test data is externalized through JSON files.
* GitHub Actions uploads generated `.trx` and `.html` test result artifacts after test execution.
