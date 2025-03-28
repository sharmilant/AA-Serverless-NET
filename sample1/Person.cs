namespace sample1;

class Person{
    public string name{ get; set;}
    public int age {get; set;}

    public  Person(string name_,int age_){
        this.name = name_;
        this.age = age_;
    }
    public string Hello(bool isLowercase){
        string message = "hello " + name + " you are " + age + ".";
        return isLowercase? message : message.ToUpper();

    }

}
