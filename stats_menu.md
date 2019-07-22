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