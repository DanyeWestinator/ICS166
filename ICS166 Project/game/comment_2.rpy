label com2:

    #Show Zeus
    scene farm_back
    show z_temp at pos_left

    #Show Farmer
    show f_temp at pos_right
    hide phone2
    image phone_com2 = "phone.png"

    z "Farmer, there is something I have been meaning to ask."
    j "It's Jonathan but go for it."
    z "How does this phone contraption work anyways? How does one enchant such an object without the will of the Gods?"
    j "Its not like that, humans don't have to rely on magic anymore.
    It just allows people to communicate with each other over a long distance."
    z "Quite a novel device, but where are the nymphs delivering these messages? It has been a lonely 12 hours. "
    j "There aren't any. It uses electricity and some wave stuff to send the message."
    z "Electricity! Are you claiming mortals have harnessed some of my divine power?"
    j "In a way, I guess. I am not sure how they do it but electricity is used for a lot of things. Like the lights in this room for example."
    z "The lights you say."
    j "Yep. Here, I think I have a spare lightbulb somewhere here if you want to take a look."
    hide f_temp
    "He goes into a storage closet."
    show f_temp at pos_right
    j "Here"
    "He lightly tosses the dust covered lightbulb."
    z "Quite a curious little thing"
    "The lightbulb begins to faintly glow as Zeus touches the bottom."
    j "Wait, that is actually pretty cool."
    z "Of course I am \"cool\" I am a God."
    j "No, the lightbulb. It doesn't normally glow just by touching it. It has to be powered by something."
    z "I am the lord of thunder after all, what did you expect?"
    j "You know what, fair point."
    j "Actually thinking about it, you could use this to get some more followers."
    z "Go on, Continue."
    j "We could record you powering some lightbulbs with just your hands. I am sure thats something people don't see every day."
    z "Yes, you have proven yourself quite useful, Farmer. Prepare the phone for this recording."

    hide f_temp
    hide z_temp
    $ post("desc2","bulb",0.5)

    #Show Zeus
    show z_temp at pos_left
    #Show Farmer
    show f_temp at pos_right

    z "And there we have it. With this I will have my powers back in no time."
    j "Looks like the post is getting some attention. Here have a look"

    p "MrElectricidad: Wow it looks like real magic!!!!"
    p "wakeupsheeple: It is obviously fake. The editing is not even that good."
    menu:
        p "Reply?"

        "What mortal dares call my powers fake!":
            $ follow_count += 1
        "Just wait till I smite thee for your foolish remarks":
            $ follow_count += 3
        "Ignore it":
            $ follow_count += 2
            j "Sometimes it best to just ignore people like that."
            jump com2_2

    z "What mortals would dare risk provoking my wrath. You humans have lost all disiplne."
    j "That is pretty par for the course nowadays. You can't really trust stuff that people post."
    z "How could they not believe it, they have eyes. They can clearly see my power."
    j "Ya, but there are many ways to fake stuff like this. You are going to need something even more spectacular if you want more people to follow."
    jump com2_2

label com2_2:
    p "yahooOo00oo: wats the secret"
    p "jChillin: P cool how did u do it?"
    j "Knock on wood, but we'll have you home in no time."

    return
