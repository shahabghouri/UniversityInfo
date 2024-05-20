import { UniversityDomain } from "./UniversityDomain";
import { WebPage } from "./WebPage";

export class UniversityInfo{
    id:number;
    name:string;
    alpha_two_code:string;
    country:string;
    state_province:string;
    web_pages:WebPage[];
    domains:UniversityDomain[];
    constructor(){
        this.id = 0;
        this.name = "";
        this.alpha_two_code = "";
        this.country = "";
        this.state_province = "";
        this.web_pages = [];
        this.domains = [];
    }
}