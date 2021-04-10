import { class_type } from "./.fable/fable-library.3.1.2/Reflection.js";
import { Interop_reactApi } from "./.fable/Feliz.1.41.0/Interop.fs.js";
import react$002Dhighlight from "react-highlight";
import { createElement } from "react";
import { printf, toText } from "./.fable/fable-library.3.1.2/String.js";
import { ofArray, singleton } from "./.fable/fable-library.3.1.2/List.js";

export class Highlight {
    constructor() {
    }
}

export function Highlight$reflection() {
    return class_type("Shared.Highlight", void 0, Highlight);
}

export function code(c) {
    return Interop_reactApi.createElement(react$002Dhighlight, {
        className: "fsharp",
        children: c,
    });
}

export function fixDocsView(fileName, client) {
    const children = singleton(createElement("a", {
        href: toText(printf("https://github.com/tforkmann/Feliz.ReactFlow/blob/main/src/Docs/views/Feliz.ReactFlow/%s.fs"))(fileName),
        children: ("Fix docs file " + fileName) + " here",
    }));
    return createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children)),
    });
}

export function installationView(packageName) {
    let s, elms, elms_1;
    const children_2 = ofArray([(s = toText(printf("%s - Installation"))(packageName), createElement("h1", {
        className: "title is-1",
        children: s,
    })), createElement("hr", {}), (elms = ofArray([createElement("h4", {
        className: "title is-4",
        children: "Use Paket",
    }), code(toText(printf("paket add %s"))(packageName))]), createElement("div", {
        className: "content",
        children: Interop_reactApi.Children.toArray(Array.from(elms)),
    })), (elms_1 = ofArray([createElement("h4", {
        className: "title is-4",
        children: "Add react flow npm package",
    }), code("npm install --save react-flow-renderer")]), createElement("div", {
        className: "content",
        children: Interop_reactApi.Children.toArray(Array.from(elms_1)),
    }))]);
    return createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children_2)),
    });
}

