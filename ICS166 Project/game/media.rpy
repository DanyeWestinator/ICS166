#The screen for the social media portion of the game

#File Define
image p_image = im.Scale("im_blank.png", 600, 350)
image option1 = im.Scale("test_1.png", 600, 350)

#Variable init
init:
    $ p_text = "Post Description"
    $ p_tag = "#PostTag"


#The Screen
screen media:

    #Initial Background
    #black background plus phone draw
    add im.Scale("back_black.jpg", 1980, 1200)
    add "phone" xalign 0.01 yalign 0.80

    #Elements of a post
    add "p_image" xalign 0.12 yalign 0.1
    text p_text xpos 320 ypos 500
    text p_tag xpos 320 ypos 600

    imagebutton:
        idle im.Scale("post.png", 400, 100)
        xalign 0.17
        yalign 0.9
        action Return()


    #Selecting elements of a post
    #Post image
    imagebutton:
        idle "option1"
        xalign 0.8
        yalign 0.1
        #action SetScreenVariable("p_text","Changed")
        action SetScreenVariable("p_image","option1")


    #Text Options
    textbutton "Change Desc_1":
        xpos 1100
        ypos 600
        action SetScreenVariable("p_text","Changed 1")
    textbutton "Change Desc_2":
        xpos 1400
        ypos 600
        action SetScreenVariable("p_text","Changed 2")


    #Tag Options
    textbutton "Change Tag_1":
        xpos 1100
        ypos 800
        action SetScreenVariable("p_tag","#Changed 1")
    textbutton "Change Tag_2":
        xpos 1400
        ypos 800
        action SetScreenVariable("p_tag","#Changed 2")
