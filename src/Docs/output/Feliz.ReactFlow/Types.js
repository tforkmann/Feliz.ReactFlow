import { Record, toString, Union } from "../.fable/fable-library.3.1.2/Types.js";
import { record_type, int32_type, union_type } from "../.fable/fable-library.3.1.2/Reflection.js";

export class EdgeType extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Bezier", "Straight", "Step", "SmoothStep"];
    }
}

export function EdgeType$reflection() {
    return union_type("Feliz.ReactFlow.EdgeType", [], EdgeType, () => [[], [], [], []]);
}

export function EdgeType__get_Value(this$) {
    return toString(this$).toLocaleLowerCase();
}

export class ArrowHead extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Arrow", "ArrowClosed"];
    }
}

export function ArrowHead$reflection() {
    return union_type("Feliz.ReactFlow.ArrowHead", [], ArrowHead, () => [[], []]);
}

export function ArrowHead__get_Value(this$) {
    return toString(this$).toLocaleLowerCase();
}

export class NodeType extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Input", "Output", "Default"];
    }
}

export function NodeType$reflection() {
    return union_type("Feliz.ReactFlow.NodeType", [], NodeType, () => [[], [], []]);
}

export function NodeType__get_Value(this$) {
    return toString(this$).toLocaleLowerCase();
}

export class position extends Record {
    constructor(x, y) {
        super();
        this.x = (x | 0);
        this.y = (y | 0);
    }
}

export function position$reflection() {
    return record_type("Feliz.ReactFlow.position", [], position, () => [["x", int32_type], ["y", int32_type]]);
}

