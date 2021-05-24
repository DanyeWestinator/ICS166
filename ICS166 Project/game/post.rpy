#The screen for the social media portion of the game

#File Define
image p_image = im.Scale("im_blank.png", 600, 350)
image option1 = im.Scale("test_1.png", 600, 350)
image desc_test = "desc_test.png"
image bulb = "p_img_blub.png"
image flex = "p_img_flex.png"
image phonec = "p_img_phone.png"
image strike = "p_img_strike.png"

init python:
    follow_count = 0

    def post(desc_img,pimage,x_pos):
        renpy.show("phone",at_list=[Position(xpos=x_pos, ypos=0.99)])
        renpy.show(pimage,at_list=[Position(xpos=x_pos, ypos=0.4)])
        renpy.show(desc_img,at_list=[Position(xpos=x_pos, ypos=0.86)])
        renpy.pause()
