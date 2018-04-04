# Online-Game-Collector-Friend
A handy python and C# script that puts all your games from GOG, Steam, and Origin in a text file.
No login required!

# Instructions
1. For any of this to work, you'll need the webpage with all of your games. So log in to your respective account and download the webpage (in firefox and chrome: save page as... Webpage, complete).
- For GOG (save as gog.html): https://www.gog.com/account (use list mode to be sure)
- For Steam (save as steam.html): http://steamcommunity.com/id/[---insert your steam ID here---]/games/?tab=all
- For Origin (save as origin.html): https://www.origin.com/usa/en-us/game-library

2a. If your using the C# application, all you need to do is throw all of the html files and the exe in the same folder and you should be good to go (even if your missing a site or two)
2b. Same for python, just make sure you have the re (regular expression) library (pip install re). 

If something isn't working, double check that you:
- Saved the complete html
- Saved the complete html as described above (gog.html for gog, etc...)
- EVERYTHING is in the same folder
