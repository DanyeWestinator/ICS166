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
        "With many groans of pain, Zeus climbs from the inside of the crater"
        "He gestures behind him, down the sloping twenty feet of smouldering rubble"
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
                j "Oh, only a few thousand miles away"

        j "But you're not {i}actually{/i} Zeus right?"
        j "That has to be a bit!"
        z "Big beard, white robe, able to withstand meteoric impacts, who else did you think I was?"
        j "To be frank, I just assumed homeless."
        z "I am not lacking a home!"
        z "*scoffs* HA!\nImpudent Mortal"
        z "I have a home, it's at the top of a very tall mountain called Olympus"
        z "I'm sure even you have heard of it"
        menu:
            "Well, that's roughly halfway around the world":
                j "And the nearest airport is about eighty miles away"
                z "The Lord of the Skies needs no port of air, I can fly myself there."
                "Zeus takes a running leap, and faceplants into the gravel road"
                z "It would seem my powers of flight are still beyond my injured state."
                j "Well, I can't offer you Mount Olympus, but I have a spare couch, and I can drive you to the Greyhound station in the morning"
                jump offer_couch

            "Oh, you really think you're Zeus, don't you?":
                z "By Pan's horn shavings, yes!"
                j "You haven't seen any men in white coats, have you?"
                z "No, the last person I saw was Kronos, a legion of monsters surrounding him"
                z "Artemis and I cut a path through the hoarde, even our powers unable to threaten those numbers."
                z "He knocked her aside, and froze her in a flash of golden light."
                z "I battled him thunderbolt to scythe, until he swept my legs from under me."
                z "There was a flash of light, and the next thing I knew, I was hundreds of feet in the sky, and I fell into that crater."
                j "Well, that doesn't entirely rule out government labs doing weird experiments again"
                j "But I haven't the slightest idea how to even begin helping you there"
                j "I have a bachelors in farm management, this is a bit above my pay grade"
                j "But the least I can offer you is a couch to crash on, and a ride to the Greyhound station in the morning."
                j "Er, your majesty"
                z "Lord Zeus, if you please."
                jump offer_couch
            "I don't know how the hell you got into this crater, but I'm starting to feel you took some brain damage in the landing":
                z "Nonsense!"
                z "This crash is nothing. I've taken plenty worse battle hits before"
                j "Silly me. I figured any god that could crash into a field like a meteor could teleport"
                z "For some mystical reason, I seem to be bereft of my normal powers"
                j "Sure, buddy."
                j "Well, I can offer you my couch, and I can drive you back to whatever facility you escaped from in the morning"
                jump offer_couch


        jump offer_couch


    label offer_couch:
        z "Even the gods are not too humble to accept charity from mortals"
        z "Hopefully couches in this land are as comfortable as the ones on Olympus."
        z "They're made of actual clouds!"
        j "Well, you'll be getting the finest of IKEA, your majesty"
        z "Just Lord Zeus, if you don't mind"
        "The car drives away as the pounding sound of Led Zeppelin fills the air"
