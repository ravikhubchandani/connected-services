@echo off
:: Create exchange
rabbitmqadmin -u guest -p guest -V / declare exchange name=exchange1 type=direct

:: Create queue
rabbitmqadmin -u guest -p guest -V / declare queue name=queue1

:: Bind exchange and queue
rabbitmqadmin -u guest -p guest -V / declare binding source=exchange1 destination=queue1

