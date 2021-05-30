label s2:
    scene dark_road

    z "This chariot is a wonderful invention. Hephaestus would be proud."
    $ z_2_pos = Position(xpos=0.2, ypos=0.75)
    show z_2 at z_2_pos
    z "You must be a wealthy man indeed to possess such a treasure."
    $f_drive_pos = Position(xpos=0.8, ypos=0.8)
    show f_drive at f_drive_pos
    j "You wanna walk around a farm twenty miles in every direction? Be my guest."
    j "Everyone's got a truck 'round these parts."
    scene farm_back
    show f_temp at pos_right
    j "Mi casa es Zeus casa."
    show z_temp at pos_left
    z "This home is most charming. And a pleasant temperature. It was frightfully cold outside, even for me."
    j "Oh, yeah, that's just the thermostat."
    j "I'd offer you the spare bedroom, but it's still full of boxes from the move."
    j "Yeah, it's been three years, but I still haven't gotten around to buying a spare bed for the room."
    z "Speaking of years, I would not be surprised if Kronos worked some temporal trickery when he hit me."
    z "Tell me, John of Diere, how many years have passed since the Athenian victory at Marathon?"
    z "A century? Two?"
    z "The technology seems to have advanced greatly, has it truly been three centuries?"
    menu:
        j "Wait, how long has it actually been since Ancient Greece again?"

        "500 years?":
            z "Wow, it is somehow worse that I feared."
            z "Such a far distance into my own future is almost unthinkable."
            j "Wait, that doesn't sound quite right."
            z "Oh thank goodness, I thought it was much too far."


        "2500 years?":
            z "Oh, by the stomach lining of Kronos, that's further than I thought."


        "5000 years?":
            z "Now that is just simply not possible."
            j "Hmm, I think you're right."
            z "It couldn't be a tenth that far."
    j "Well, I'm pretty sure the Greeks were right before Jesus,"
    j "And that was 2,000 years ago."
    z "This Jesus fellow must be important if you remember when he lived so clearly."
    j "People wrote a book about the things he and his dad, the One True God™, said."
    j "His book club has been making world affairs about them for most of history since."
    "*pulls out phone*"
    j "According to Google, 2331 years to be exact."
    jump discovers_phone
    label discovers_phone:
        z "Another fabulous device, I take it?"
        j "Oh this? This is called a phone. If you think Jesus's followers have a grip on society,"
        j "You should see our dependence on these little doohickies."
        z "What can it do? It appears to be glowing."
        j "Well, it's really everything a modern American needs at the touch of a finger at all times."
        j "They even stuck a flashlight in these things."
        z "A flash light?"
        j "Like a torch, minus the fire."
        j "It also has access to all of humanity's collective knowledge at the touch of a button, and can instantly communicate with any human anywhere on earth."
        z "You must all be well informed, then."
        j "HA! As if!"
        j "We mainly use it to look at pictures of butts and be rude to strangers anonymously."
        j "You'll love your trip in the twenty-first century."
        z "This trip will be a temporary, and hopefully short, one."
        j "I was rather hoping that were the case. I don't have time for a Greek god at the moment."
        z "The second my powers return to me, as is right and proper, I will return to my own time."
        j "I can't even begin to plan how that might happen. So for now, goodnight Lord Zeus."
        z "Now, was that so hard!"
