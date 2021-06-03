label com3:
    scene farm_back
    #Show Zeus
    show z_temp at pos_left
    #Show Farmer
    show f_temp at pos_right

    "*that night*"
    j "Wow, this social media plan has done much better than I expected."
    z "Well of course, did you really doubt that I, Zeus himself, couldn't win over the population. I have done it before; I can do it again"
    j "You still got a way to go though. We need to think of something that will really grab people if this is going to work."
    z "Worry not, Farmer. With more of my powers back, I have a time-tested plan for just the occasion."
    j "The name's still Jonathan but, I really want to know how you have possibly tested getting social media follower back in ancient Greece."
    z "See now, Farmer, there is no better way to make the mortals respect the king of Olympus than with lightning itself."
    j "Please don't tell me you are going to electrocute someone."
    z "Of course not, at least not now anyways."
    j "Let's try and keep it that way."
    z "Now go prepare the phone, I will fine a perfect spot for such a display."
    j "There is not really anything to prepare, it doesn't exactly take a long time to open the photo app."
    z "Hurry it up, I have been waiting to use my powers again."

    hide z_temp
    hide f_temp
    scene bg_temp
    "Shortly after in the nearby fields."

    #Show Zeus
    show z_temp at pos_center

    z "This looks like an adequete spot."
    z "Time to warm up the lightning. It has been far too long."
    "The skies start to turn dark all around."
    "There is a static in the air."
    z "Now bear witness to the powers of a god."
    scene bolt_strike
    "zzzzzzzzzz-CRACK!!"


    hide z_temp
    $ post("desc3","strike",0.5)

    #prob shift to indoor background
    scene bg_temp

    #Show Zeus
    show z_temp at pos_left
    #Show Farmer
    show f_temp at pos_right

    z "Now what did I tell you?"
    j "You are right. This one is going viral."
    z "I expected no less. Now let me see what the mortals are saying about it."

    #Include a few responce options and prob a few more comments to sell the going viral thing
    p "Ne4Sunny: Wow this guy might actually be legit"
    p "getgotttttten: we get it you can photoshop some lighting in the background congrats"
    p "itBSmackin: DAMN this boi be looking like Zeus up in here"
    p "abfg157: bring the thunder"
    p "lel49m8: prefect timeing on dat one"
    "Suddenly, the skies darken again. These clouds are darker and more full than earlier."
    "The smell of static is thick in the air, when suddenly, a bolt of lightning arcs down and collides with Zeus."
    hide f_temp
    hide z_temp
    show z_hit at truecenter
    "Far from being killed, this seems to energize him. As the bolt hit him, he dropped to one knee, but then rose again, his eyes flashing with power.
    Lightning fills his fingers, and every fiber of his being screams \"This is a God!\""
    hide z_hit
    show z_temp at truecenter
    z "Now, that's what I've been talking about when I mention power."





    return
