label com1:

    #Initial Background
    scene farm_back

    #Show Zeus
    scene farm_back
    show z_temp at pos_left

    #Show Farmer
    show f_temp at pos_right
    hide phone2

    "Sometime the next morning."
    j "Hey come over here. It looks like a few people actually commented on the post."
    z "Where are these people? I do not see any other mortals around."
    j "No, on the phone. Come over here and look."

    image phone2 = "phone_com1.png"
    show phone2 at truecenter

    p "Steve77: nice"

    z "Yes, Steve77, this phone drawing of me is exceptionally fine."
    j "You know they can't hear you right?"
    z "What are you taking about? They have ears don't they?"
    j "That's not how this works. If you want to talk them you are going to have to type it out."
    j "Look do you see that reply button, press it and you can type out a message for them."

    menu:
        p "Reply?"
        "Yes Steve77 this phone drawing of me is exceptionally fine.":
            $ follow_count += 1

    j "Also, it's called a picture by the way"

    p "The_HatEnthusiast: Nice hat. Looks like some fine quality leather. Where did you pick it up?"
    p "JuiceMan: What are you some kind of cowboy get with the times"

    menu:
        p "Reply?"

        "I am not the son of Pasiphaë!":
            $ follow_count += 1
        "Luckily I have lightning powers to roast you, since you are the cow boy here":
            $ follow_count += 3
        "Ignore it":
            $ follow_count += 0
            return

    j "You don't know what a cowboy is do you?"
    z "Of course I do, he prowled the Labyrinth."
    j "No, they work on farms like mine. They're boys that work with cows."
    z "No one names things clearly anymore."
    j "*Sigh*"

    return
