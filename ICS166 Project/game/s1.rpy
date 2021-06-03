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

    scene crater
    "*distant explosion*"
    show f_temp at pos_right
    j "What the hell was that?"

    menu:
        j "What should I do?"

        "Investigate":

            jump helps
        "Don't investigate":
            scene dark_road
            "You drive away, worry about the explosion gnawing at your insides."
            "As the dirt road stretches out before you, the matter fades quickly from your mind."
            scene farm_back
            "You arrive home, the prospect of Kraft Mac-n-cheese and CSI: Moon reruns are the only thing planned for tonight."
            "As the remote slips from your hand as sleep grips you, the explosion is driven fully from your mind,
                to be replaced with thoughts of a growing mortgage and increasingly unprofitable soy farming."
            $ e_end = True
            return


    label helps:
        "The bumpy farm roads rocks the car as it trundles along the dirt path."
        "You eventually come across a crater, some fifty feet off the road."
        "The crater is smoking, with flames still licking around the edges."
        "Inside the crater lies a man."
        u "*muffled groaning*"
        u "Oh that'll really put the millenia on someone."
        show z_temp at pos_left
        hide explosion
        menu:

            "Sir, do you need any help?":
                u "No, actually, dirt pits are quiet comfortable.
                    Though if you don't mind terribly, I would like to leave this particular one."
                u "I'd get myself out, but my limbs don't seem to want to move properly just yet. That was a hell of a landing I just made."
            "Oh good god, are you still alive????":
                u "Technically, yes,"
                u "Though I likely took a pretty severe beating in the crash. \nNone of this looks familiar."

        j "What do you mean you landed here? Did you see what made the crater?"
        "With many groans of pain, the man climbs from the inside of the crater."
        "He gestures behind him, down the sloping twenty feet of smouldering rubble."
        u "I don't think you seem to be getting that I made this crater."
        menu:
            "That's not possible.":
                j "You'd have died on impact!"
                u "Do I look dead to you?"
                j "No?"
                u "Can you see any other way this crater got made?"
                j "Gas explosion?"
                u "Hah! Gas explosion! Why do mortals never want to accept that there's a divine presence before them?"
                j "Divine presence?"
                u "Is it not obvious, I am Zeus."
            "Hah! Good one!":
                j "And I'm Zeus!"
                u "No, I am."
                j "...What?"
                z "Who did you think I was?"
                j "Funnily enough, I hadn't considered coming across the Lord of the Skies while in my field in North Dakota"
                z "Is that near Sparta?"
                j "Oh, only a few thousand miles away"

        j "My name's Johnathan Deir, but you can call me Jack.
            Seems a mite rude for me to know what you claim your name to be, but not for you to know mine"
        j "...You're not {i}actually{/i} Zeus right? That has to be a bit!"
        z "Big beard, white robe, able to withstand meteoric impacts, who else did you think I was?"
        j "To be frank, I just assumed homeless."
        z "I am not lacking a home! \n*scoffs* HA!\n\nImpudent Mortal"
        z "I have a home, it's at the top of a very tall mountain called Olympus. I'm sure even you have heard of it."
        menu:
            "Well, that's roughly halfway around the world.":
                j "And the nearest airport is about eighty miles away."
                z "The Lord of the Skies needs no port of air, I can fly myself there."
                "Zeus takes a running leap, and faceplants into the gravel road."
                z "It would seem my powers of flight are still beyond my injured state."
                j "Well, I can't offer you Mount Olympus, but I have a spare couch, and I can drive you to the Greyhound station in the morning."
                jump offer_couch

            "Oh, you really think you're Zeus, don't you?":
                z "By Pan's horn shavings, yes!"
                j "You haven't seen any men in white coats, have you?"
                z "No, the last person I saw was Kronos; a legion of monsters surrounding him.
                Artemis and I cut a path through the hoarde, even our powers unable to threaten those numbers.
                He knocked her aside, and froze her in a flash of golden light."
                z "I battled him thunderbolt to scythe, until he swept my legs from under me.
                There was a flash of light, and the next thing I knew, I was hundreds of feet in the sky, and I fell into that crater."
                j "Well, that doesn't entirely rule out government labs doing weird experiments again.
                But I haven't the slightest idea how to even begin helping you there."
                j "I have a bachelors in farm management, this is a bit above my pay grade.
                But the least I can offer you is a couch to crash on, and a ride to the Greyhound station in the morning."
                j "Er, {i}your majesty{/i}."
                z "Lord Zeus, if you please."
                jump offer_couch
            "I don't know how the hell you got into this crater, but I'm starting to feel you took some brain damage in the landing.":
                z "Nonsense!"
                z "This crash is nothing. I've taken plenty worse hits in battle before."
                j "Silly me. I figured any god that could crash into a field like a meteor could teleport"
                z "For some mystical reason, I seem to be bereft of my normal powers"
                j "Sure, buddy."
                j "Well, I can offer you my couch, and I can drive you back to whatever facility you escaped from in the morning"
                jump offer_couch


        jump offer_couch


    label offer_couch:
        z "Even the gods are not too humble to accept charity from mortals."
        z "Hopefully couches in this land are at least half as comfortable as the ones on Olympus."
        z "They're made of actual clouds!"
        j "Well, you'll be getting the finest of IKEA, {i}your majesty.{/i}"
        z "Just Lord Zeus, if you don't mind."
        "The car drives away as the pounding sound of Led Zeppelin fills the air."
