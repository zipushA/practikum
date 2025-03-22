export class principal{
    constructor(
        public name: string,
        public password: string,
        public email: string,
        public schoolName:string,
        public matchingDataId?:number,
        public id?:number
    )
    {}
}