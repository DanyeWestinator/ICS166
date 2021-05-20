label s1:

    #Initial Background
    scene bg_temp

    #Show Zeus
    show explosion at top
    pause 1
    show explosion at truecenter
    pause 1
    show explosion at center
    pause 2

    "*distant explosion*"
    show f_temp at pos_right
    j "What the hell was that?"

    menu:
        j "What should I do?"

        "Investigate":

            jump helps
        "Don't investigate":
            "You drive away, worry about what that explosion was gnawing away at your insides."
            "Eventually, curiousity and possible property damage force your hand to turn the car around"
            j "Dammit, I was this close to being done for the night"
            jump helps


    label helps:
        "The bumpy farm roads rocks the car as it trundles along the dirt path"
        "You eventually come across a crater, some fifty feet off the road"
        "The crater is smoking, with flames still licking around the edges"
        "Inside the crater lies a man"
        z "*muffled groaning*"
        z "oh that'll really put the millenia on someone"
        show z_temp at pos_left
        menu:
            "Sir, do you need any help?":
                z "no, actually, dirt pits are quiet comfortable"
                z "Though if you don't mind terribly, I would like to leave this particular one."
                z "I'd get myself out, but my limbs don't seem to want to move properly just yet."
                z "That was a hell of a landing I just made"
            "Oh good god, are you still alive????":
                z "Technically, yes"
                z "Though I likely took a pretty severe beating in the crash. \nNone of this looks familiar"

        j "What do you mean you landed here? Did you see what made the crater?"
        z "I don't think you seem to be getting that I made this crater."
        menu:
            "That isn't possible.":
                j "You'd have died on impact!"
                z "Do I look dead to you?"
                j "No?"
                z "Can you see any other way this crater got made?"
                j "Gas explosion?"
                z "Hah! Gas explosion! Why do mortals never want to accept that there's a divine presence before them?"
            "Hah! Good one!":
                j "And I'm Zeus!"
                z "No, I am."
                j "...What?"
                z "Who did you think I was?"
                j "Funnily enough, I hadn't considered coming across the Lord of the Skies while in my field in North Dakota"
                z "Is that near Sparta?"

        j "But you're not {i}actually{/i} Zeus right?"
        j "That has to be a bit!"
        z "Big beard, white robe, able to withstand meteoric impacts, who else did you think I was?"
        j "To be frank, I just assumed homeless."


    return
