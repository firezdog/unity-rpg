* class Item -- name, description, value, image, modifier
* kinds of Items: Weapon, Armor, Health Potion, Magic Potion
  * modifiers affect different stats in each case
  * what about hybrids -- like equipping a sword as a shield or vice versa?  Special class?  Is it too much too have a separate class for health and magic potions?
    * https://www.reddit.com/r/gamedev/comments/1hp3jk/oop_game_coding_should_i_create_a_class_to_every/
      * MoreOfAnOvalJerk -- use composition rather than inheritance
        * https://www.gamasutra.com/blogs/MeganFox/20101208/88590/Game_Engines_101_The_EntityComponent_Model.php
      * so the idea could be this -- you have a restoreHealth component that restores some health to a character, a restore magic component that restores some magic to a character, an equipAsWeapon component or equipAsArmor component that adds bonuses to relevant stats...then each item involves these various components -- so you could have various kinds of multi-potions with both magic and health restoring capabilities etc.  But each item is probably a prefab with an item script attached, and the item script then contains an array of its components or something?
      * https://gamedev.stackexchange.com/questions/147873/creating-a-robust-item-system

# Game Engines 101: The Entity / Component Model
* Why not to use classes
* entities as data stores with attached components
  * the components modify the shared data and may or may not be aware of each other
* example: a monster
  * sprite, physics, AI -- the AI decides how to move and passes that on to the monster; the physics takes the plan and creates a trajectory; the sprite animates the trajectory etc.
* example: trap
  * trigger, explosion -- trigger defines area -- when the area is occupied, it tells the entity it has been "triggered" -- and then the explosion component, based on the trigger, sends out messages to update motion of the entity that triggered (or nearby entities)

# Creating a Robust Item System
* User wanted to create a flexible item system with lots of features (items can -- be upgraded, modify stats, be recharged / exhausted, exist in sets, be enchanted, have rarity levels, be crafted, be consumed)
* The solution: items have lists of attributes; attributes and items can send each other messages -- that's basically it.  From my understanding, a player might use one of the items, causing the item to then send a message to each of its attributes that it has been used.  The attributes then respond accordingly -- communicating back with the item itself or with other pieces of the system.
  * I think that this displaces the "if" checks that would happen at the level of the item to the components.  For instance, say that I have a sword -- I can do various things with this sword -- I can equip it, attack with it, or enchant it.  Each of these actions is a message that the item would proliferate, I suppose, to all its components.  Those components, according to their type, would then react to or ignore that message.  So if I have a sword and I attack with it, I send out the "attack" message to the components -- the attack component responds and then hooks up with whatever other systems are involved in an attack; whereas the "enchantable" or "equippable" components don't care.  The only downside of this is that any message has to be proliferated to all of the components.  Would it be better to have a dictionary of components?

* I ended up creating an Item : ScriptableObject and an ItemObject: MonoBehavior to server as a wrapper.  Right now (9/24/19) the Item is very basic -- just a name, description, and sprite -- but I will use the entity pattern described above to fill it out as more functionality is needed.  The game will interface with the ItemObject, the ItemObject will interface with the Item, and the Item will interface with its attributes.