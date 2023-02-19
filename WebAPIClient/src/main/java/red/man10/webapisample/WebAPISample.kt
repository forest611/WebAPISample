package red.man10.webapisample

import okhttp3.*
import okhttp3.MediaType.Companion.toMediaType
import okhttp3.RequestBody.Companion.toRequestBody
import org.bukkit.Bukkit
import org.bukkit.command.Command
import org.bukkit.command.CommandSender
import org.bukkit.plugin.java.JavaPlugin
import java.io.IOException

class WebAPISample : JavaPlugin() {

    companion object{

        val client = OkHttpClient()

    }

    override fun onEnable() {
        // Plugin startup logic
    }

    override fun onDisable() {
        // Plugin shutdown logic
    }

    override fun onCommand(sender: CommandSender, command: Command, label: String, args: Array<out String>?): Boolean {

        if (label=="get"){

            get(sender)

            return true
        }

        if (label=="post"){

            post(sender)

            return true
        }

        return true
    }

    val url = ""
    val mediaType = "application/json; charset=utf-8".toMediaType()
    val testJson = ""


    fun get(sender: CommandSender){

        val request = Request.Builder()
            .url(url)
            .build()

        var responseMsg = "NoMessage"

        try {
            val response = client.newCall(request).execute()
            responseMsg = response.body?.string()?:"Null"
        }catch (e:IOException){
            sender.sendMessage(e.message?:"Exception(Message Is Null)")
        }

        sender.sendMessage(responseMsg)
    }

    fun post(sender: CommandSender){

        val body = testJson.toRequestBody(mediaType)
        val request = Request.Builder()
            .url(url)
            .post(body)
            .build()

        var responseMsg = "NoMessage"

        try {
            val response = client.newCall(request).execute()

            responseMsg = response.body?.string()?:"Null"

        }catch (e:IOException){
            sender.sendMessage(e.message?:"Exception(Message Is Null)")
        }

        sender.sendMessage(responseMsg)
    }
}