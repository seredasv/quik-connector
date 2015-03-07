﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikConnector.Orders
{
    //0 – транзакция отправлена серверу,  
    //1 – транзакция получена на сервер QUIK от клиента, 
    //2 – ошибка при передаче транзакции в торговую систему, поскольку отсутствует подключение шлюза Московской Биржи, повторно транзакция не отправляется, 
    //3 – транзакция выполнена, 
    //4 – транзакция не выполнена торговой системой, код ошибки торговой системы будет указан в поле «DESCRIPTION»,
    //5 – транзакция не прошла проверку сервера QUIK по каким-либо критериям. Например, проверку на наличие прав у пользователя на отправку транзакции данного типа,  
    //6 – транзакция не прошла проверку лимитов сервера QUIK, 
    //10 – транзакция не поддерживается торговой системой. К примеру, попытка отправить «ACTION = MOVE_ORDERS» на Московской Бирже, 
    //11 – транзакция не прошла проверку правильности электронной подписи. К примеру, если ключи, зарегистрированные на сервере, не соответствуют подписи отправленной транзакции 
    //12 – не удалось дождаться ответа на транзакцию, т.к. истек таймаут ожидания. Может возникнуть при подаче транзакций из QPILE 
    //13 – транзакция отвергнута, т.к. ее выполнение могло привести к кросс-сделке (т.е. сделке с тем же самым клиентским счетом) 


    public enum ReplyCode
    {
        SentToServer = 0,
        ReceivedOnServer = 1,
        GatewayError = 2,
        Executed = 3,
        NotExecutedByTradeSystem = 4,
        VerifiedFail = 5,
        VerifiedLimitsFail = 6,
        NotSupportedByTradeSystem = 10,
        ElectronicSignatureError = 11,
        ExpiredTimeout = 12,
        CrossTradeError = 13
    }
}
