label com1:

    #Initial Background
    scene bg_temp

    #Show Zeus
    show z_temp at pos_left

    #Show Farmer
    show f_temp at pos_right

    j "Hey come over here. It looks like some people are commenting on the post"
    z "Where are these people? I do not see any other mortals around"
    j "No, look on the phone."

    p "User1: Nice One."
    p "User2: Damn this dude b ripped"
    p "User3: it is ob fake just look at it."

    menu:
        "Reply?"

        "What mortal dares call my powers fake!":
            $ follow_count += 1
        "Just wait till I smite thee for your foolish remarks":
            $ follow_count += 3
        "Ignore it":
            $ follow_count += 2

    z "Well then"
    p "Current Follower Count: [follow_count]"

    hide f_temp

    z "Here are some other possible scenes/posts:"
    z "One where Zeus discovers how electronics and stuff harness lightning for mortal use"
    $ post("desc_test","bulb",0.7)
    z "Could have a post of him lighting up a lightbub with only his fingers"
    z "Could have an additional one based on this concept where he is charging up a phone by placing is finger on the end of a charger"
    $ post("desc_test","phonec",0.7)
    z "Could have one just showing off how ripped and strong he is since he is a godly being"
    z "The post could just be him flexing for the camera and stuff"
    $ post("desc_test","flex",0.7)
    z "One where Zeus has more of his power and commands a lighting strike behind him"
    z "The post would be him looking looking smug with the lightning crash lighing up the background"
    $ post("desc_test","strike",0.7)



    return
