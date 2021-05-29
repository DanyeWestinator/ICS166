# Characters:
#   Farmer  -> j
#   Zeus    -> z

label s4:

    # Initial Background
    scene bg_temp

    # Show Farmer
    show f_temp at pos_left

    j "Can you explain to me how your powers work."
    j "I can kind of understand that you are Zeus, but how did you go from Greek god to a strange toga-wearing man on the side of the road?"
    
    show z_temp at pos_right

    z "Well, during the age of the Greek gods, people believed that the gods controlled all of nature."
    z "Take my brother Poseidon for example. That dude's the god of the ocean."
    z "Demeter reigned over agriculture."
    z "And of course I was ..."

    hide f_temp
    hide z_temp
    "As Zeus rambled on about his magnificence, Farmer's mind began to drift elsewhere."

    show f_temp at pos_left
    j "(What should I make for dinner?)"
    j "(Since I went out to eat yesterday, I didn't get to milk the cows so I'm out of that)"
    j "(mmmmh butter)"

    hide f_temp
    "...er"
    "...armer"
    show z_temp at pos_left
    z "Hey Farmer!"

    show f_temp at pos_right
    j "!!"
    j "Ah sorry about that. Just nodded off a little."
    j "Have you finally finished your monologue?"

    z "You know, I'm starting to think I'm not getting the respect I deserve."
    z "Anyways, as I was saying."
    z 'Have you ever head of the saying, "If you believe in something hard enough, it\'ll come true"?'

    j "Yeah. What about it?"

    z "Great, that makes this a lot easier."
    z "The power of the gods was pretty much dependent on the people who worshipped them. The more the gods were worshipped, the stronger their power became."

    j "Just out of curiosity, how much power do you have now?"

    z "I should be able to shoot a lightning bolt or two."
    z "Hagh"

    hide f_temp
    hide z_temp
    "Much to Zeus\'s surprise, only a small flicker of lightning spouted from his hands before quickly disappearing."

    show z_temp at pos_left
    z "..."
    show f_temp at pos_left
    j "..."

    return
