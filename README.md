# fetch-league-data
Fetch LOL win rate data and present the information in an excel file.

## Summary
Fetches data for specified Leage Of Legends champions and outputs their win rates for each elo including their win rates after 50 games per elo. On the second tab of the excel file you'll see chart data comparing each champ across each elo. A second chart is displayed that filters the data between specified elos.

## Setup
Before you build you just need to update the config files. 

### appsettings.json
In the appsettings file you'll need to change url to use the website that I used (message me to request url) and can update the directory you want to output your save file to. 

### characters.json
Use this file to specify all characters that you are interested in including in the report. Reference allConfigOptions.json for all available champs.

### elos.json
Use startElo and stopElo to specify the elo range to be used in the final chart. Reference allConfigOptions.json for all available elos that you can specify.

### allConfigOptions.json
This file isn't used in the application, rather it is a master config file with available options for the elos.json and characters.json files.

## Run
Assuming the config files are set up correctly, you can run the exectuable that results from building the solution and it will output an excel file to the location specified in the appsettings.json file. 

## Note
- EPPLus requires a license to debug but not to run so unless you have a license, you will get an exception if you try to debug the application.
