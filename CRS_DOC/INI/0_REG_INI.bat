@echo off
del 00-REG_INI.SQL
for /f %%i in ('dir /b /n *.sql') do (type %%i >> 00-REG_INI.TEMP  & echo. >> 00-REG_INI.TEMP & echo GO )
RENAME 00-REG_INI.TEMP 00-REG_INI.SQL