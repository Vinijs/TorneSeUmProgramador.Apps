#Ferramentas de Desenvolvimento
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/downloads/)
- [Srccpy](https://github.com/Genymobile/scrcpy)


#Links Úteis

- [O que é MAUI?](https://learn.microsoft.com/pt-br/dotnet/maui/what-is-maui)
- [Baixando Srccpy](https://github.com/Genymobile/scrcpy/blob/master/doc/windows.md)
- [Publicar um aplicativo Android usando a linha de comando](https://learn.microsoft.com/pt-br/dotnet/maui/android/deployment/publish-cli?view=net-maui-8.0)

#Comandos úteis
##Gerar chave keystore
keytool -genkeypair -v -keystore {filename}.keystore -alias {keyname} -keyalg RSA -keysize 2048 -validity 10000

##Comando para assinar o aplicativo
dotnet publish -f ne7.0-android -c Release -p:AndroidKeyStore=true -p:AndroidSigningKeyStore={filename}.keystore -p:AndroidSigningKeyAlias={keyname} -p:AndroidSigningKeyPass={password} -p:AndroidSigningStorePass={password}

