# Caesar
A cli tool to encode/decode a string use caesar code by me.

# How to use
```
Caesar.exe PARAM -s STRING -k KEY
```

PARAM:   Program's running mode.<br>
         encode -> To encode the STRING with KEY step(s).<br>
         decode -> To decode the STRING with KEY step(s).<br>
         help   -> Check out the help page.<br>
<br>
STRING:  The string you are going to deal with, followed by '-s'.<br>
         If there is SPACE in your STRING, use " " to surround it.<br>
         By the way, numbers and symbols(include ') will not change.<br>
         But if STRING includes ",consider use '\"' instead.<br>
<br>
KEY:     Define the number of step(s) to encode/decode the STRING.<br>
         The KEY value must between 1 and 25.<br>

**Only avaliable on Windows yet.**
