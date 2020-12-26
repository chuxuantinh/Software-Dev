class Stringer {
    constructor(a, b) {
        this.innerString = a;
        this.innerLength = Number(b);
    }
    decrease(num){
       return this.innerLength = Math.max(0, this.innerLength - num);
    }
    increase(num){
        return this.innerLength += num;
    }
    toString(){
        if(this.innerLength >= this.innerString.length){
            return this.innerString;
        }
        else {
            return `${this.innerString.substr(0, this.innerLength)}...`;
        }
    }
}