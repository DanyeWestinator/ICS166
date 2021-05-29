label com3:

    #Show Zeus
    show z_temp at pos_left
    #Show Farmer
    show f_temp at pos_right

    j "Wow, this social media plan has done much better than I expected."
    z "Well of course, did you really doubt that I, Zeus himself, couldn't win over the population. I have done it before I can do it again"
    j "You still got a ways to go though. We need to think of something that will really grab people it this is going to work."
    z "Worry not farmer. With more of my powers back, I have a time-tested plan for just the occasion."
    j "The name's still Jonathan but, I really want to know how you have possibly tested getting social media follower back in ancient Greece."
    z "See now farmer, there is no better way to make the mortals respect the king of Olympus than with lightning itself."
    j "Please don't tell me you are going to electrocute someone."
    z "Of course not, atleast not now anyways."
    j "Lets try and keep it that way."
    z "Now go perpare the phone, I will fine a perfect spot for such a display."
    j "There is not really anything to prepare, it only takes like two seconds to open up the photo app."
    z "Hurry it up, I have been waiting to use my powers again."

    hide z_temp
    hide f_temp
    scene bg_temp
    "Shortly after in the nearby fields."

    #Show Zeus
    show z_temp at pos_center

    z "This looks like an adequete spot."
    z "Time to warm up the lightning. It been too long."
    "The skys start to turn dark all around."
    "There is a static in the air."
    z "Now bare witness to the powers of a god."
    "zzzzzzzzzz-CRACK!!"
    "####Show a white flash here#####"

    hide z_temp
    $ post("desc_test","strike",0.5)

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





    return
