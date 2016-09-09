package in.slyther.gameobjects;

import com.google.flatbuffers.FlatBufferBuilder;
import in.slyther.math.Vector2;
import slyther.flatbuffers.SnakePartState;
import slyther.flatbuffers.SnakeState;
import slyther.flatbuffers.Vec2;

public class SnakePart {
    private Vector2 position;

    public SnakePart(Vector2 position) {
        this.position = position;
    }


    public int serialize(FlatBufferBuilder builder, int index) {
        int positionOffset = Vec2.createVec2(builder, position.getX(), position.getY());

        SnakePartState.startSnakePartState(builder);
        SnakePartState.addIndex(builder, index);
        SnakePartState.addPosition(builder, positionOffset);

        return SnakePartState.endSnakePartState(builder);
    }


    public Vector2 getPosition() {
        return position;
    }

    public void setPosition(Vector2 position) {
        this.position = position;
    }
}
