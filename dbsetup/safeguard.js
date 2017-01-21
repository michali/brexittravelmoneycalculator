DB.prototype.dropDatabase = function(){
    print ("Database not dropped. Did you mean to do that?");
}

db.dropDatabase = DB.prototype.dropDatabase;