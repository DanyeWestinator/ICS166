define c = Character("Chimera")
image chimera = "chimera.png"

label fight_scene:

    scene dark_road

    show f_temp at pos_left
    show z_temp at pos_right

    z "How much longer are we going to keep driving?"

    j "Relax, we\'re almost hom-"

    hide f_temp
    hide z_temp

    "ROOOAAARRR"

    show z_temp at pos_left

    z "What the he-"
    z "WATCH OUT!!"

    hide z_temp

    "*CRASH*"

    "As Jack and Zeus were returning home after a long day,
     a mysterious object collided into them, sending their
     car barreling."

    ""

    show z_temp at pos_left
    z "Ugh"
    z "What in the name of Hades' clammy beer belly was that?"
    z "Hey Farmer, are you dead?"

    show f_temp at pos_right
    j "Not yet."

    z "Well we might be soon."

    hide f_temp
    hide z_temp

    "Standing before them was the legendary beast Chimera."
    show chimera at truecenter
    show z_temp at pos_left
    z "What is a beast from ancient times doing here?"
    z "Was it Kronos again?"

    show f_temp at pos_right
    j "We need to get away from here fast!"

    z "I don\'t think we can."
    z "That thing will catch up quickly."
    z "We have to fight it."

    j "Fight it?"
    j "With what? You barely have any power and I can barely fight."

    z "We can take it. Do you have any metal objects in the car?"

    j "I have a shovel."

    z "Good, go get it."

    j "I don\'t know what you\'re planning but alright."

    hide f_temp

    z "Hey Chimera, over here! Take this!"

    "*ZAP*"

    hide z_temp

    c "ROOOAAARRR"

    show z_temp at pos_left
    z "Nothing huh?"
    z "That pelt is going to be a problem."
    z "Woah"

    hide z_temp

    "Zeus dodges as the Chimera's claws barely misses his head."

    show z_temp at pos_left
    z "Hey Farmer, have you found that shovel yet?!"

    hide z_temp
    show f_temp at pos_right

    j "I almost got it!"
    j "And {i}hrngh{/i}"
    j "Alright, got it. Catch!"

    hide f_temp
    show z_temp at pos_left

    z "Good"
    z "Now come at me Chimera!"

    hide z_temp

    c "ROOOAAAARRRR!!"

    "As Zeus provokes it, the Chimera prepares to breath its
    flames. Zeus readies his shovel, charging it with lightning."

    show z_temp at pos_left

    z "Wait for it."
    z "Wait for it."
    z "Now!"
    z "HAAAA!!"

    hide z_temp

    "The moment the Chimera opened its mouth, Zeus launched
    the shovel as if it were his own lightning bolt, piercing
    the Chimera\'s throat."

    "The lightning surrounding the shovel began melting the
    insides of the Chimera, killing it within a minute."

    show z_temp at pos_left

    z "That was a close fight."
    z "Hey Farmer, can you still drive the car?"

    show f_temp at pos_right

    j "No, that crash really did it in."
    j "Luckily we are not too far from home."
    j "I\'ll just call a tow truck to get it."

    z "You mean we have to walk the rest of the way there?"
    z "*sigh*"
    z "Well let us go then. The faster we start, the sooner I can sleep."

    j "Yeah"
    j "It\'s been a long day."

    z "A long day indeed."

    return
