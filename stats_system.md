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
* Tutorial uses 105% of previous level for next level (exponential).
## Testing Leveling
* Develop system that will level up the player (and increase stats?) _when the player gains enough experience for the next level_.
* Plan: every update, levelUp() will run to check player experience -- if player's experience matches next level req's, level will be increased.
* Testing can be done very simply -- just set initial experience past threshold and see if level goes up.
* public IncreaseExp() -- only check level when experience is added (instead of at update)
* tutorial substracts exp for next level to reset? (apparently 1.05 is not going to be enough -- you probably want 2.05x?)
* uses input for test (Input.GetKeyDown)
* next step -- stats go up on leveling (big scaling questions here)
## Gaining Stats On Level Up
* tutorial
* add to strength / defence on alternate levels
* just use some multiplier for hp
* remember to reset current hp (and mp)
* for mp create array of mp level bonuses (I don't like this) -- similar to custom exp i set up...
* indexOutOfRange errors when you reach maximum level and then you keep gaining exp -- instead add a guard
## Creating Game Manager
* we need a way to keep track of player stats (depending on the player profile)
* game manager (hold game state) -- unity gives default icon
* create game manager object to hold our new script (and load it with loader?)
* create a static public instance variable and don't destroy on load
* create reference to an array of stat controllers (in case we want more than one character)
* Note about "Loader" -- the loader *script* loads prefabs -- but under the loader prefab are game objects that get instantiated with it in each scene and are separate from the script behavior.  We (probably) DON'T want the loader to be a singleton, because the objects instantiated with it, like the grid, will have different values between scenes (e.g. different maps) and we want to be able to instantiate a new loader whose instances have preset values in each scene.
  * This leads to somewhat of a problem -- because the game manager is a singleton that gets attached to the loader (like the player sprite), but (at least for testing purposes) the game manager might have specific values assigned to it (specific characters under it).
