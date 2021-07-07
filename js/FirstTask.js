class Shape
{
    square(){}
}
class Quad extends Shape
{
    constructor(sideLength){
        super();
        this.sideLength=sideLength;
    }
    square(){
        super.square();
        return this.sideLength*this.sideLength;
    }
}
class Rectangle extends Shape
{
    constructor(sideWidth,sideHeight){
        super();
        this.sideWidth=sideWidth;
        this.sideHeight=sideHeight;
    }
    square(){
        super.square();
        return this.sideWidth*this.sideHeight;
    }
}
var quad=new Quad(5);
var rectangle=new Rectangle(5,10);
console.log(quad.square());
console.log(rectangle.square());
