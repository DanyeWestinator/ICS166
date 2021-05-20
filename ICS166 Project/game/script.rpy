﻿#Global Defines
define z = Character("Zeus")
define j = Character("Jonathan Deir")
define p = Character("Phone")

#File Defines
image z_temp = im.Scale("z_temp.png",700,800)
image f_temp = im.Scale("f_temp.png",700,800)
image phone = im.Scale("phone.png", 900,1050)

image bg_temp = "back_temp.jpg"
image explosion = "explosion.png"

#init vars
init:
    #Standard Positions for characters on the screen
    $ pos_left = Position(xpos=0.2, ypos=0.9)
    $ pos_right = Position(xpos=0.8, ypos=0.9)
    $ pos_center = Position(xpos=0.5, ypos=0.9)

# The game starts here.
label start:
    # Scene control
    # In order to add a scene to the game call the label for your scene
    # and add it in the correct spot
    # For ease of editing and source control keep your scenes in seperate
    # files called s#.rpy based on which scene you are doing
    # Keep any sub scenes you descide to create out of the main so it is clean
    call s1
    #call screen media

    #End game
    z "This will end the game"
    return