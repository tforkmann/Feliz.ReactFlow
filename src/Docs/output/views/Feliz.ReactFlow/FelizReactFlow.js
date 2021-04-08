import { createElement } from "react";
import { Interop_reactApi } from "../../.fable/Feliz.1.40.1/Interop.fs.js";
import { ofArray } from "../../.fable/fable-library.3.1.2/List.js";
import { installationView, fixDocsView } from "../../Shared.js";

export const overview = (() => {
    let elms, elms_2, elms_3, children_3;
    const children_6 = ofArray([(elms = ofArray(["Feliz.ReactFlow - Documentation", createElement("a", {
        href: "https://www.nuget.org/packages/Feliz.ReactFlow/",
        children: Interop_reactApi.Children.toArray([createElement("img", {
            src: "https://img.shields.io/nuget/v/Feliz.ReactFlow.svg?style=flat",
        })]),
    })]), createElement("h1", {
        className: "title is-1",
        children: Interop_reactApi.Children.toArray(Array.from(elms)),
    })), createElement("h2", {
        className: "subtitle is-2",
        children: Interop_reactApi.Children.toArray(["Fable bindings for ReactFlow."]),
    }), createElement("hr", {}), (elms_2 = ofArray([createElement("p", {
        children: ["ReactFlow is a powerfulll data grid."],
    }), createElement("p", {
        children: ["ReactFlow contains multiple filters and grouping features"],
    })]), createElement("div", {
        className: "content",
        children: Interop_reactApi.Children.toArray(Array.from(elms_2)),
    })), (elms_3 = ofArray([createElement("h4", {
        className: "title is-4",
        children: "Features",
    }), (children_3 = ofArray([createElement("li", {
        children: ["column interactions (resize, reorder and pin columns="],
    }), createElement("li", {
        children: ["Pagination"],
    }), createElement("li", {
        children: ["Sorting"],
    }), createElement("li", {
        children: ["Row selection"],
    }), createElement("li", {
        children: ["Data export"],
    })]), createElement("ul", {
        children: Interop_reactApi.Children.toArray(Array.from(children_3)),
    }))]), createElement("div", {
        className: "content",
        children: Interop_reactApi.Children.toArray(Array.from(elms_3)),
    })), fixDocsView("FelizReactFlow", false)]);
    return createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children_6)),
    });
})();

export const installation = installationView("Feliz.ReactFlow");

