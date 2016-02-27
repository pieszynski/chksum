# chksum
Wyliczanie sum kontrolnych plików

* SHA1 - MODE="-sha1", domyślnie
* SHA256 - MODE="-sha256"

Podanie `HASH` spowoduje weryfikację sumy kontrolnej, brak tego parametru po prostu wyliczy sumę kontrolną.

Sposób użycia:

	\> chksum.exe [MODE] [HASH] sciezka_do_pliku

Przykład użycia:

	\> chksum.exe -sha1 9ded3ce2ae09c37ca173bbd3dcb57258b72cdbd5 putty.exe

Wynik:

	[OK]    9DED3CE2AE09C37CA173BBD3DCB57258B72CDBD5        *putty.exe
