@echo off
taskkill /fi "WindowTitle eq ne_frontend*"
taskkill /fi "WindowTitle eq ne_backend*"