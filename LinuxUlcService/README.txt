ѕерейти в каталог /etc/systemd/system
—оздать файл с именем ulc.service и добавить в него следующее:
----------------------------------------------------------------------------------------------
[Unit]
Description=—ервис дл€ опроса контроллеров ULC

[Service]
User=root
WorkingDirectory=/samba/LnxUlcService
ExecStart=dotnet /samba/LnxUlcService/LinuxUlcService.dll
Restart=always

[Install]
WantedBy=multi-user.target
---------------------------------------------------------------------------------------------
√де можно использовать следующие параметры:

[Unit] - основна€ часть службы
Description - описание вашего сервиса
After - указываем, после какого сервиса запускать службу (например, nginx.service, mysql.service). ћожно указывать построчно несколько значений этого параметра.
Requires=nginx.service - дл€ запуска службы об€зательно необходим сервис ngnix (указать любой другой)
Wants=redis.service - какой сервис должен быть запущен при желании (не об€зателен, чисто как доп. инфа)
[Service] - блок с настройками сервиса
User - от имени какого пользовател€ выполн€етс€ сервис
Group - группа, от которой выполн€ть сервис
WorkingDirectory - рабоча€ директори€ службы
ExecStart - выполн€ема€ команда, например, выполнение php скрипта (полный и точный путь к скрипту)
Restart - указываем, что необходимо автоматически делать рестарт службы в случае отвала
TimeoutSec=200 - врем€, сколько ждать перед запуском/остановкой сервиса
OOMScoreAdjust=-100 - запрет на отключение сервиса, в случае нехватки пам€ти
[Install] - параметры установки службы
WantedBy - уровень запуска, многопользовательский режим

ѕерезагрузите файлы службы:
sudo systemctl daemon-reload

«апустите свой сервис:
sudo systemctl start ulc.service

ќстановка сервиса:
sudo systemctl stop ulc.service


ѕроверьте статус сервиса:
sudo systemctl status ulc.service

„тобы включить/отключить сервис при каждой перезагрузке, использовать команды:
sudo systemctl enable ulc.service
sudo systemctl disable ulc.service

