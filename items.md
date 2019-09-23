* class Item -- name, description, value, image, modifier
* kinds of Items: Weapon, Armor, Health Potion, Magic Potion
  * modifiers affect different stats in each case
  * what about hybrids -- like equipping a sword as a shield or vice versa?  Special class?  Is it too much too have a separate class for health and magic potions?
    * https://www.reddit.com/r/gamedev/comments/1hp3jk/oop_game_coding_should_i_create_a_class_to_every/
      * MoreOfAnOvalJerk -- use composition rather than inheritance
        * https://www.gamasutra.com/blogs/MeganFox/20101208/88590/Game_Engines_101_The_EntityComponent_Model.php
      * so the idea could be this -- you have a restoreHealth component that restores some health to a character, a restore magic component that restores some magic to a character, an equipAsWeapon component or equipAsArmor component that adds bonuses to relevant stats...then each item involves these various components -- so you could have various kinds of multi-potions with both magic and health restoring capabilities etc.  But each item is probably a prefab with an item script attached, and the item script then contains an array of its components or something?
      * https://gamedev.stackexchange.com/questions/147873/creating-a-robust-item-system