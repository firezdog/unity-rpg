# Layout
* Add panel to UICanvas
    * UI > Panel
    * UI asset -- panel image, "Menu"
    * add UI > Button, position in upper left and adjust
        * blurriness: 16x9 res vs UI => 1920x1080
        * text: "Items", image: from assets, text color -> white
        * add more buttons
            * Stats
            * Save
            * Close
            * Quit
        * consistent positioning: you could edit it by hand (calculate) but Unity has a system -- create "buttons" object with children = buttons
        * vertical layout component on "buttons"
            * now you can specify the margin for each
* Add panel within panel, top-right: char-info
    * character image (stop stretching -- preserve aspect)
        * we want this to be dynamic based on which icon the player is using
    * text for character name (w/ best fit, min and max size)
    * text for different attributes (HP, MP, next level, level) 
        * -- is there also a vertical layout for the text? (grid w/ rows and columns)
        * slider for exp to next level
            * remove background image
                * grayish color
            * remove sprite from fill area
                * blue
            * handle slide area: delete the handle
            * changing values will fill up the exp bar 
                * (never totally full or empty -- make fill go back to edge for start and end)
            * we also want text w/ precise value: text under exp in center of slider
    * duplicate for three characters (are these party members?) with a vertical layout group
    * third character is deactivated (object unchecked in the editor) option to deactivate
# Toggling The Menu
* Create script for menu w/ reference to game menu
* Desired functionality -- open menu on right click (fire2)
* toggle activeInHierarchy
* Desiderata / bugs: player can still move.
    * Player can also move in loading areas
# Stop Player Movement
* Note that simply toggling player movement false when menu or dialog box are active and then true when deactivated leads to a bug where player movement is incorrectly toggled on cross-activation.  I'm not sure the best way to fix this bug, so I'm leaving it for now.
    * I wonder if it wouldn't be best to have a global menuOpen, say in GameManager, and then have GameManger set player as being able to move or not move based on that state (we need to make player movement reactive)
* Solution: we manage the state using the Game Manager -- only Game Manager is allowed to set player movement, and the other controllers make calls to the game manager.
* If any of the bools is true, we keep player from moving.