# Caesar
A cli tool to encode/decode a string use caesar code by me.

# How to use
```
Caesar.exe PARAM -s STRING -k KEY
```

PARAM:   Program's running mode.
         encode -> To encode the STRING with KEY step(s).
         decode -> To decode the STRING with KEY step(s).
         help   -> Check out the help page.

STRING:  The string you are going to deal with, followed by '-s'.
         If there is SPACE in your STRING, use " " to surround it.
         By the way, numbers and symbols(include ') will not change.
         But if STRING includes ",consider use '\"' instead.

KEY:     Define the number of step(s) to encode/decode the STRING.
         The KEY value must between 1 and 25.

**Only avaliable on Windows yet.**
