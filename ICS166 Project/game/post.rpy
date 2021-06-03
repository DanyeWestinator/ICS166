#The screen for the social media portion of the game

#File Define
image p_image = im.Scale("im_blank.png", 600, 350)
image option1 = im.Scale("test_1.png", 600, 350)
image desc_test = "desc_test.png"
image desc2 = "desc_com2.png"
image bulb = "p_img_bulb.png"
image flex = "p_img_flex.png"
image phonec = "p_img_phone.png"
image strike = "p_img_strike.png"
image desc3 = "desc3.png"
image mall_com = im.Scale("mall_com.png", 800, 200)
image mall_girl = im.Scale("mall_girl.jpg", 500, 450)

init python:
    follow_count = 0

    def post(desc_img,pimage,x_pos = 0.5):
        renpy.show("phone",at_list=[Position(xpos=x_pos, ypos=0.99)])
        renpy.show(pimage,at_list=[Position(xpos=x_pos, ypos=0.45)])
        renpy.show(desc_img,at_list=[Position(xpos=x_pos, ypos=0.7)])
        renpy.pause()
