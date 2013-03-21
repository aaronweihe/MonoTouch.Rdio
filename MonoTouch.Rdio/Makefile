BTOUCH=/Developer/MonoTouch/usr/bin/btouch

all: Rdio.dll

Rdio.dll: Makefile ApiDefinition.cs Rdio.a StructsAndEnums.cs
	$(BTOUCH) -unsafe ApiDefinition.cs Rdio.linkwith.cs StructsAndEnums.cs --out=$@ --link-with=Rdio.a,Rdio.a 

clean:
	-rm -f *.dll