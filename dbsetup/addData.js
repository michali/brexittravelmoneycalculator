db = db.getSiblingDB('brexittmc')

var addCountries = function(){
    db.countries.insert({_id:1, name:"Spain", currency_id:1});
    db.countries.insert({_id:2, name:"Greece", currency_id:1});;
    db.countries.insert({_id:3, name:"Sweden", currency_id:6});
    db.countries.insert({_id:4, name:"South Korea", currency_id:4});;
    db.countries.insert({_id:5, name:"Japan", currency_id:7});
    db.countries.insert({_id:6, name:"Unites States of America", currency_id:2});
    db.countries.insert({_id:7, name:"Canada", currency_id:5});  
    db.countries.insert({_id:8, name:"Italy", currency_id:1});
    db.countries.insert({_id:9, name:"Portugal", currency_id:1});
};

var addCurrencies = function(){
    db.currencies.save({_id:1,
        code: "EUR", 
        name: "Euro",
        exchangeRate: 1.16, 
        lastUpdated: new Date('2017-01-20T22:34:59.301Z')});

    db.currencies.save({_id:2, 
        code: "USD", 
        name: "US Dollar",
        exchangeRate: 1.24, 
        lastUpdated: new Date('2017-01-20T22:34:59.301Z')});

    db.currencies.save({_id:3, 
        code: "AUD", 
        name: "Australian Dollar" ,
        exchangeRate: 1.64, 
        lastUpdated: new Date('2017-01-20T22:34:59.301Z')});

    db.currencies.save({_id:4, 
        code: "KRW", 
        name: "South Korean Won",
        exchangeRate: 1454.43, 
        lastUpdated: new Date('2017-01-20T22:34:59.301Z')});

    db.currencies.save({_id:5, 
        code: "CAD", 
        name: "Canadian Dollar",
        exchangeRate: 1.65, 
        lastUpdated: new Date('2017-01-20T22:34:59.301Z')});
    
    db.currencies.save({_id:6, 
        code: "SEK", 
        name: "Swedish Krona",
        exchangeRate: 1, 
        lastUpdated: new Date('2017-01-20T22:34:59.301Z')});

    db.currencies.save({_id:7, 
        code: "JPY", 
        name: "Japanese Yen",
        exchangeRate: 141.82, 
        lastUpdated: new Date('2017-01-20T22:34:59.301Z')});
}

addCountries();
addCurrencies();