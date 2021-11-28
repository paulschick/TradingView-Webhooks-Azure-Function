# TradingView Webhook Alerts | Azure Function

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Version](https://badge.fury.io/gh/tterb%2FHyde.svg)](https://badge.fury.io/gh/tterb%2FHyde)

## Overview

I am building this as a small project to help learn Azure Functions for the AZ-204 exam.
The project uses Azure Functions and Azure Blob Storage.
I'll be adding more to this project, it's mainly for fun and somewhat useful for a trading
strategy that I'm researching.

The Azure Function receives a webhook alert from TradingView.
This triggers the function to retrieve prices of cryptocurrencies of interest from CoinGecko.
The data is then added to a CSV file in blob storage.

## To Dos

- Add TradingView alert format and example 
- Create custom alert strategy on TradingView
