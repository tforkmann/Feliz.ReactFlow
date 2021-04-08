import { Union } from "./.fable/fable-library.3.1.2/Types.js";
import { union_type } from "./.fable/fable-library.3.1.2/Reflection.js";
import { RouterModule_encodeParts } from "./.fable/Feliz.Router.3.8.0/Router.fs.js";
import { singleton } from "./.fable/fable-library.3.1.2/List.js";

export class Page extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["FelizReactFlow", "FelizReactFlowInstallation", "FelizReactFlowExampleFlow"];
    }
}

export function Page$reflection() {
    return union_type("Router.Page", [], Page, () => [[], [], []]);
}

export const defaultPage = new Page(0);

export function parseUrl(_arg1) {
    let pattern_matching_result;
    if (_arg1.tail != null) {
        if (_arg1.head === "") {
            if (_arg1.tail.tail == null) {
                pattern_matching_result = 0;
            }
            else {
                pattern_matching_result = 3;
            }
        }
        else if (_arg1.head === "installation") {
            if (_arg1.tail.tail == null) {
                pattern_matching_result = 1;
            }
            else {
                pattern_matching_result = 3;
            }
        }
        else if (_arg1.head === "exampleflow") {
            if (_arg1.tail.tail == null) {
                pattern_matching_result = 2;
            }
            else {
                pattern_matching_result = 3;
            }
        }
        else {
            pattern_matching_result = 3;
        }
    }
    else {
        pattern_matching_result = 3;
    }
    switch (pattern_matching_result) {
        case 0: {
            return new Page(0);
        }
        case 1: {
            return new Page(1);
        }
        case 2: {
            return new Page(2);
        }
        case 3: {
            return defaultPage;
        }
    }
}

export function getHref(_arg1) {
    switch (_arg1.tag) {
        case 1: {
            return RouterModule_encodeParts(singleton("installation"), 1);
        }
        case 2: {
            return RouterModule_encodeParts(singleton("exampleflow"), 1);
        }
        default: {
            return RouterModule_encodeParts(singleton(""), 1);
        }
    }
}

