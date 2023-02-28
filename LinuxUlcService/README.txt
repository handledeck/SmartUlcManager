������� � ������� /etc/systemd/system
������� ���� � ������ ulc.service � �������� � ���� ���������:
----------------------------------------------------------------------------------------------
[Unit]
Description=������ ��� ������ ������������ ULC

[Service]
User=root
WorkingDirectory=/samba/LnxUlcService
ExecStart=dotnet /samba/LnxUlcService/LinuxUlcService.dll
Restart=always

[Install]
WantedBy=multi-user.target
---------------------------------------------------------------------------------------------
��� ����� ������������ ��������� ���������:

[Unit] - �������� ����� ������
Description - �������� ������ �������
After - ���������, ����� ������ ������� ��������� ������ (��������, nginx.service, mysql.service). ����� ��������� ��������� ��������� �������� ����� ���������.
Requires=nginx.service - ��� ������� ������ ����������� ��������� ������ ngnix (������� ����� ������)
Wants=redis.service - ����� ������ ������ ���� ������� ��� ������� (�� ����������, ����� ��� ���. ����)
[Service] - ���� � ����������� �������
User - �� ����� ������ ������������ ����������� ������
Group - ������, �� ������� ��������� ������
WorkingDirectory - ������� ���������� ������
ExecStart - ����������� �������, ��������, ���������� php ������� (������ � ������ ���� � �������)
Restart - ���������, ��� ���������� ������������� ������ ������� ������ � ������ ������
TimeoutSec=200 - �����, ������� ����� ����� ��������/���������� �������
OOMScoreAdjust=-100 - ������ �� ���������� �������, � ������ �������� ������
[Install] - ��������� ��������� ������
WantedBy - ������� �������, ��������������������� �����

������������� ����� ������:
sudo systemctl daemon-reload

��������� ���� ������:
sudo systemctl start ulc.service

��������� �������:
sudo systemctl stop ulc.service


��������� ������ �������:
sudo systemctl status ulc.service

����� ��������/��������� ������ ��� ������ ������������, ������������ �������:
sudo systemctl enable ulc.service
sudo systemctl disable ulc.service

