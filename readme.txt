ASP.NET MVCでページを編集・追加する
https://qiita.com/shironana/items/41c35b5ca3c2532f5ad9

【ViewModel】ASP.NET MVCでサーバー側と画面側でデータを受け渡す
https://qiita.com/shironana/items/06ec2cb2e17fb064a857

ASP.NET MVCにデータベースを接続する
https://qiita.com/shironana/items/18d38933324a3e4276ee

ASP.NET MVCでデータベースを操作する
https://qiita.com/shironana/items/9125feba6454901d5465

dotnet run
docker build -t gourmet .
docker run -it --rm -p 5000:8080 --name gourmetContainer gourmet

dotnet publish -c Release -o published
dotnet published/GourmetApplication.dll

docker build -t gourmet .
docker run -it --rm -p 5000:8080 --name gourmetContainer gourmet


●Docker サポートの追加によるコンテナ実行
https://qiita.com/idoudougirl/items/9eca5cfcf893c92f6921
https://learn.microsoft.com/ja-jp/visualstudio/containers/overview?view=vs-2019

1. Dockerfileを.slnと同じ場所へ移す
　 COPYコマンドはDockerfileからの相対パス指定のため、.csprojと同じ場所のままだと.csprojが見つからず、
　 not foundエラーになる

2. docker build -t gourmet .
3. docker run -it --rm -p 5000:8080 --name gourmetContainer gourmet
4. ドッカーに入る
docker ps 
docker container exec -it コンテナ名(コンテナID) bash


4. dockerではなく、dotonet runで直接起動
dotnet run --project GourmetApplication/GourmetApplication.csproj

●コンテナからホストSQLSeverへの接続
https://docs.sakai-sc.co.jp/article/programing/docker-sqlserver.html
上記のすべての設定が必要

●コンテナに入り、Pingコマンドを打つ
https://uepon.hatenadiary.com/entry/2022/05/04/210941

docker container exec -it a938ea842aa7 bash
apt update
apt install iputils-ping net-tools

IPアドレス調べ方
hostname -i

Dockerfileに記述しても可
RUN apt update && apt install -y iputils-ping net-tools