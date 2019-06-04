# Section 7: Leveling Up
## Player Stats
* Keep track of player stats on individual characters using stat manager script
* This should be really simple -- just a script with some variables (like health, magic, exp), getters, setters -- attached to player. Tricky point might be making sure that player doesn't get new stats each time she loads. Maybe instead of putting script on character, it is put on game manager (singleton) object?
## Adding Leveling System
* Leveling system -- required experience increases for each level. Strategy: keep exp for each level in an array and check req. exp. dynamically. (seems like some kind of algorithm would be just as efficient.)
* Considerations: level req's can increase either geometrically or linearly. In favor of geometrically -- you gain more exp. at higher levels (appearance of greater rewards) -- would also prevent farming low level enemies / challenges and keep game more balanced?
* You can expect in a standard game, characters would go to level 60 or so.  First level req is normally around 1000 -- but it seems ridiculous to have level 60 req's go to the billions.  How about splitting levels into landmarks and having the growth be exponential for each landmark?  Say every 10 levels, req's grow exponentially, but linearly until then?
* Tutorial: use array and max level. Expose array to allow tweaking?  Or you could combine -- use formula AND allow tweaking.
* Set a maxLevel (expose it to editor, make it const?)
* Concern -- if formula determines exp req's at START -- then what if you want to update them?  Check in method if it has non-zero value?
* Use base exp (accessible from editor) to "seed" level req's.
* To allow user some freedom both in setting number of max level and max level variables, create separate array for custom scores (up to max allowed max level) and then fill in those scores when initializing.
## Testing Leveling
## Gaining Stats On Level Up
## Creating Game Manager